using System;
using System.Collections.Generic;

namespace FakeNewsDetectionCache.Entities.Models
{
    public partial class Vote:Entity
    {
        //public int Id { get; set; }
        public bool IsTrue { get; set; }
        public int NewsArticleId { get; set; }
        public int ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual NewsArticle NewsArticle { get; set; }
    }
}
