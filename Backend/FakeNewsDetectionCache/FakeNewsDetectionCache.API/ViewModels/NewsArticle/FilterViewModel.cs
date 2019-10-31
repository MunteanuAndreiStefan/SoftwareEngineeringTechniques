using System;
using FakeNewsDetectionCache.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FakeNewsDetectionCache.API.ViewModels.NewsArticle
{
  public class FilterViewModel : BaseFilterViewModel<Entities.Models.NewsArticle>
  {
    public string filterBySource { get; set; }
    public int? filterByUserId { get; set; } 
    public override System.Linq.Expressions.Expression<Func<Entities.Models.NewsArticle, bool>> GetFilter()
    {
      Expression<Func<Entities.Models.NewsArticle, bool>> filter = x => true;
      Expression<Func<Entities.Models.NewsArticle, bool>> sourc = x => x.Source==filterBySource;



      var body = Expression.AndAlso(filter.Body, sourc.Body);
      var ee = Expression.Lambda(body, filter.Parameters[0]);
       
      return ee.Body;
      //var xx = new Expression<Func<Entities.Models.NewsArticle, bool>>();

      //if(filterBySource!=null)
      //filter
    }
  }
}
