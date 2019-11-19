using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeNewsDetectionCache.API.ViewModels;
using FakeNewsDetectionCache.API.ViewModels.TwitterUser;
using FakeNewsDetectionCache.Aspects;
using FakeNewsDetectionCache.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeNewsDetectionCache.API.Controllers
{
    [Log]
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterUsersController : ControllerBase
    {

        protected ITwitterUserService TwitterUserService;

        public TwitterUsersController(ITwitterUserService tweeterUserService)
        {
            TwitterUserService = tweeterUserService;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var items = await TwitterUserService.GetAll();
            return new JsonResult(items);
        }

        [HttpPost("{model}")]
        public async Task<JsonResult> GetFiltered(TwitterUserFilterViewModel model)
        {
            var items = await model.ApplyFilter(await TwitterUserService.GetAsQueriable());
            return new JsonResult(items);
        }

        [HttpPost]
        public async Task Post(TwitterUserViewModel model)
        {
            if(ModelState.IsValid)
            await TwitterUserService.Add(model.ToEntity());
        }

        [HttpPut]
        public async Task Put(TwitterUserViewModel model)
        {
            await TwitterUserService.Update(model.ToEntity());
        }

        [HttpDelete("{Id}")]
        public async Task Delete(int Id)
        {
            var entityToDelete = (await TwitterUserService.GetByFilter(x => x.Id == Id)).FirstOrDefault();

            if (entityToDelete != null)
                await TwitterUserService.Delete(entityToDelete);
        }

    }
}