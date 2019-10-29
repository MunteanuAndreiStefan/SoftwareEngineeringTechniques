using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeNewsDetectionCache.API.ViewModels;
using FakeNewsDetectionCache.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeNewsDetectionCache.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  public class NewsArticleController : ControllerBase
  {

    protected INewsArticleService NewsArticleService;

    public NewsArticleController(INewsArticleService newsArticleService)
    {
      NewsArticleService = newsArticleService;
    }

    [HttpGet]
    public async Task<JsonResult> Get()
    {
      var items =await NewsArticleService.GetAll();
      return new JsonResult(items);
    }

    [HttpPost]
    public async Task Post(NewsArticleViewModel model)
    {
      await NewsArticleService.Add(model.ToEntity());
    }

  }
}

