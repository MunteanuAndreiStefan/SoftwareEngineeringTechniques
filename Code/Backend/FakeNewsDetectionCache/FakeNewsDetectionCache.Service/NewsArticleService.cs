using FakeNewsDetectionCache.Entities.Models;
using FakeNewsDetectionCache.Interfaces;
using FakeNewsDetectionCache.Service.Utils;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FakeNewsDetectionCache.Service
{
    public class NewsArticleService : CrudService<NewsArticle, Repository>, INewsArticleService
    {
        protected ITwitterUserService TwitterUserService;

        private string _processingUnitUrl;
        public NewsArticleService(ITwitterUserService twitterUserService,IOptions<ProcessingUnitConfig> config, Repository dbContext) : base(dbContext)
        {
            TwitterUserService = twitterUserService;
            _processingUnitUrl = config.Value.Url;
        }

        public async Task<bool> IsSourceUnique(string source)
        {
            return (await GetByFilter(x => x.Source == source)).Count == 0;
        }

        public async Task<NewsArticle> GetArticleByUrl(string url)
        {
            var newsArticle = (await GetAsQueriable()).Where(x => x.Source == url).FirstOrDefault();
            if (newsArticle == null)
                newsArticle = await ProcessUrl(url);

            return newsArticle;
        }

        protected async Task<NewsArticle> ProcessUrl(string url)
        {
            HttpClient client = new HttpClient();

            ProcessedNewsArticle processedNewsArticle = null;
            var processingUrl = _processingUnitUrl + "?tweet_url=" + url;
            HttpResponseMessage response = await client.GetAsync(processingUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                processedNewsArticle = await JsonSerializer.DeserializeAsync<ProcessedNewsArticle>(responseStream);
            }
            else
                return null;

            var user=(await TwitterUserService.GetAsQueriable()).Where(x => x.Username==processedNewsArticle.user).FirstOrDefault();
            int userId = 0;
            if(user==null)
            {
                userId=await TwitterUserService.Add(processedNewsArticle.GetTwitterUser());
            }
            else
            {
                userId = user.Id;
                user = processedNewsArticle.GetTwitterUser(user.Id);
                await TwitterUserService.Update(user);
            }

            var newsArticle = processedNewsArticle.GetNewsArticle(url, userId);
            await Add(processedNewsArticle.GetNewsArticle(url,userId));

            return newsArticle;
        }

        

    }

    internal class ProcessedNewsArticle
    {
        public string url { get; set; }

        public int score { get; set; }

        public string user { get; set; }
        public int user_score { get; set; }

        public NewsArticle GetNewsArticle(string url,int userId)
        {
            return new NewsArticle { Source = url, CredibilityScore = score, UserId = userId };
        }

        public TwitterUser GetTwitterUser()
        {
            return new TwitterUser { Username = user, CredibilityScore = user_score };
        }

        public TwitterUser GetTwitterUser(int id)
        {
            return new TwitterUser {Id=id, Username = user, CredibilityScore = user_score };
        }

    }
}
