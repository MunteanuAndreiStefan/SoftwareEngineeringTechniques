using FakeNewsDetectionCache.Entities.Models;
using FakeNewsDetectionCache.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FakeNewsDetectionCache.Service
{
    public class NewsArticleService : CrudService<NewsArticle, Repository>, INewsArticleService
    {
        public NewsArticleService(Repository dbContext) : base(dbContext)
        {

        }

        public async Task<bool> IsSourceUnique(string source)
        {
            return (await GetByFilter(x => x.Source == source)).Count == 0;
        }

    }
}
