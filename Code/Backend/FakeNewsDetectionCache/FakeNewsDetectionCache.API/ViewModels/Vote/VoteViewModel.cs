using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FakeNewsDetectionCache.API.ViewModels.Vote
{
    public class VoteViewModel
    {

        public int? Id { get; set; }
        [Required]
        public int ApplicationUserId { get; set; }
        [Required]
        public int NewsArticleId { get; set; }

        public VoteViewModel()
        {

        }

        public VoteViewModel(Entities.Models.Vote vote)
        {
            ApplicationUserId = vote.ApplicationUserId;
            NewsArticleId=vote.NewsArticleId;

        }

        public Entities.Models.Vote ToEntity()
        {
            return new Entities.Models.Vote
            {
                Id = Id ?? 0,
                ApplicationUserId = ApplicationUserId,
                NewsArticleId = NewsArticleId
            };
        }

    }
}
