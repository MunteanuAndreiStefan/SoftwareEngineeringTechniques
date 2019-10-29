using FakeNewsDetectionCache.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeNewsDetectionCache.API.ViewModels
{
  public class NewsArticleViewModel
  {
    public string Source { get; set; }
    public int? CredibilityScore { get; set; }
    public int UserId { get; set; }

    public NewsArticleViewModel()
    {

    }

    public NewsArticleViewModel(NewsArticle newsArticle)
    {
      Source = newsArticle.Source;
      CredibilityScore = newsArticle.CredibilityScore;
      UserId = newsArticle.UserId;
    }

    public NewsArticle ToEntity()
    {
      return new NewsArticle
      {
        Source = Source,
        CredibilityScore = CredibilityScore,
        UserId = UserId
      };
    }

  }
}
