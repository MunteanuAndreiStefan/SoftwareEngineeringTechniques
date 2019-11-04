using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeNewsDetectionCache.API.ViewModels;
using FakeNewsDetectionCache.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FakeNewsDetectionCache.API.ViewModels.NewsArticle;

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
            var items = await NewsArticleService.GetAll();
            return new JsonResult(items);
        }



        [HttpGet("{model}")]
        public async Task<JsonResult> GetFiltered(FilterViewModel model)
        {
            var items = await NewsArticleService.GetByFilter(model.GetFilter());
            return new JsonResult(items);
        }

        [HttpPost]
        public async Task Post(NewsArticleViewModel model)
        {
            await NewsArticleService.Add(model.ToEntity());
        }

    }
}

