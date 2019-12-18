using FakeNewsDetectionCache.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FakeNewsDetectionCache.Interfaces
{
  public interface INewsArticleService:ICrudService<NewsArticle>
  {
        Task<NewsArticle> GetArticleByUrl(string url);
  }
}
