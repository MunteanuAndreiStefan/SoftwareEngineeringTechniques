using FakeNewsDetectionCache.Entities.Models;
using FakeNewsDetectionCache.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeNewsDetectionCache.Service
{
  public class NewsArticleService:CrudService<NewsArticle,Repository>, INewsArticleService
  {
    public NewsArticleService(Repository dbContext):base(dbContext)
    {

    }
  }
}
