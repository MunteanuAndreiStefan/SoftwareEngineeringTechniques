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
    public class NewsArticlesController : ControllerBase
    {

        protected INewsArticleService NewsArticleService;

        public NewsArticlesController(INewsArticleService newsArticleService)
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
        public async Task<JsonResult> GetFiltered(NewsArticleFilterViewModel model)
        {
            var items = await model.ApplyFilter(await NewsArticleService.GetAsQueriable());
            return new JsonResult(items);
        }

        [HttpPost]
        public async Task Post(NewsArticleViewModel model)
        {
            await NewsArticleService.Add(model.ToEntity());
        }

        [HttpPut]
        public async Task Put(NewsArticleViewModel model)
        {
            await NewsArticleService.Update(model.ToEntity());
        }

        [HttpDelete("{Id}")]
        public async Task Delete(int Id)
        {
            var entityToDelete = (await NewsArticleService.GetByFilter(x => x.Id == Id)).FirstOrDefault();

            if (entityToDelete != null)
                await NewsArticleService.Delete(entityToDelete);
        }

    }
}

