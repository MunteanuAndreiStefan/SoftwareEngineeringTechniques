using FakeNewsDetectionCache.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeNewsDetectionCache.API.ViewModels
{
  public class UserViewModel
  {
    public string Username { get; set; }
    public int? CredibilityScore { get; set; }

    public UserViewModel()
    {

    }

    public UserViewModel(TwitterUser user)
    {
      Username = user.Username;
      CredibilityScore = user.CredibilityScore;
    }

    public TwitterUser ToEntity()
    {
      return new TwitterUser { 
        Username = Username, 
        CredibilityScore = CredibilityScore 
      };
    }
  }
}
