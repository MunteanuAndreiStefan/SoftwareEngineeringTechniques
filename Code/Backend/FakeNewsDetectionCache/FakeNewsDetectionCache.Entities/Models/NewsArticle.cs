using FakeNewsDetectionCache.Aspects;
using System;
using System.Collections.Generic;

namespace FakeNewsDetectionCache.Entities.Models
{
    [Monitor]
    public partial class NewsArticle:Entity
    {
        //public int Id { get; set; }
        public string Source { get; set; }
        public int? CredibilityScore { get; set; }
        public int UserId { get; set; }

        public virtual TwitterUser User { get; set; }
    }
}
