using FakeNewsDetectionCache.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeNewsDetectionCache.API.ViewModels
{
    public class NewsArticleViewModel
    {
        public int? Id { get; set; }
        public string Source { get; set; }
        public int? CredibilityScore { get; set; }
        public int UserId { get; set; }

        public NewsArticleViewModel()
        {

        }

        public NewsArticleViewModel(Entities.Models.NewsArticle newsArticle)
        {
            Source = newsArticle.Source;
            CredibilityScore = newsArticle.CredibilityScore;
            UserId = newsArticle.UserId;
        }

        public Entities.Models.NewsArticle ToEntity()
        {
            return new Entities.Models.NewsArticle
            {
                Id=Id??0,
                Source = Source,
                CredibilityScore = CredibilityScore,
                UserId = UserId
            };
        }

    }
}
