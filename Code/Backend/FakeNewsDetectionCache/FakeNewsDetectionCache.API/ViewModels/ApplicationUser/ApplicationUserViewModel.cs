using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeNewsDetectionCache.API.ViewModels.ApplicationUser
{
    public class ApplicationUserViewModel
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public int? CredibilityScore { get; set; }

        public ApplicationUserViewModel()
        {

        }

        public ApplicationUserViewModel(Entities.Models.ApplicationUser applicationUser)
        {
            Username = applicationUser.Username;
            CredibilityScore = applicationUser.CredibilityScore;
        }

        public Entities.Models.ApplicationUser ToEntity()
        {
            return new Entities.Models.ApplicationUser
            {
                Id = Id ?? 0,
                Username = Username,
                CredibilityScore = CredibilityScore
            };
        }
    }
}
