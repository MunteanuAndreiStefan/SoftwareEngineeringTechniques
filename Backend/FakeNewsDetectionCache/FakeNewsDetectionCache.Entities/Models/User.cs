using System;
using System.Collections.Generic;

namespace FakeNewsDetectionCache.Entities.Models
{
    public partial class User:Entity
    {
        public User()
        {
            NewsArticles = new HashSet<NewsArticle>();
        }

        //public int Id { get; set; }
        public string Username { get; set; }
        public int? CredibilityScore { get; set; }

        public virtual ICollection<NewsArticle> NewsArticles { get; set; }
    }
}
