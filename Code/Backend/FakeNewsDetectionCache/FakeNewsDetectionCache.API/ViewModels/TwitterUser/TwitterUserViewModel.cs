﻿using FakeNewsDetectionCache.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace FakeNewsDetectionCache.API.ViewModels
{
    public class TwitterUserViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Username { get; set; }
        public int? CredibilityScore { get; set; }

        public TwitterUserViewModel()
        {

        }

        public TwitterUserViewModel(Entities.Models.TwitterUser twitterUser)
        {
            Username = twitterUser.Username;
            CredibilityScore = twitterUser.CredibilityScore;
        }

        public Entities.Models.TwitterUser ToEntity()
        {
            return new Entities.Models.TwitterUser
            {
                Id = Id ?? 0,
                Username = Username,
                CredibilityScore = CredibilityScore
            };
        }
    }
}
