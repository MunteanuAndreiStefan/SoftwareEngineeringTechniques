using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeNewsDetectionCache.API.ViewModels.Vote;
using FakeNewsDetectionCache.Authentication.Authorization;
using FakeNewsDetectionCache.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeNewsDetectionCache.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        protected IVoteService VoteService;

        public VotesController(IVoteService voteService)
        {
            VoteService = voteService;
        }

        //[HttpGet]
        //[Authorize(Policy = Policies.OnlyExtension)]
        //public async Task<JsonResult> Get()
        //{
        //    var items = await VoteService.GetAll();
        //    if (items.Count == 0)
        //        Response.StatusCode = StatusCodes.Status404NotFound;
        //    return new JsonResult(items);
        //}

        //[HttpPost("{model}")]
        //[Authorize(Policy = Policies.OnlyExtension)]
        //public async Task<JsonResult> GetFiltered(VoteFilterViewModel model)
        //{
        //    var items = await model.ApplyFilter(await VoteService.GetAsQueriable());
        //    if (items.Count == 0)
        //        Response.StatusCode = StatusCodes.Status404NotFound;
        //    return new JsonResult(items);
        //}

        [HttpPost]
        [Authorize(Policy = Policies.OnlyDevelopers)]
        public async Task Post(VoteViewModel model)
        {
            await VoteService.Add(model.ToEntity());
        }

        [HttpPut]
        [Authorize(Policy = Policies.OnlyDevelopers)]
        public async Task Put(VoteViewModel model)
        {
            try
            {
                await VoteService.Update(model.ToEntity());
            }
            catch { Response.StatusCode = StatusCodes.Status400BadRequest; }
        }

        //[HttpDelete("{Id}")]
        //[Authorize(Policy = Policies.OnlyDevelopers)]
        //public async Task Delete(int Id)
        //{
        //    var entityToDelete = (await VoteService.GetByFilter(x => x.Id == Id)).FirstOrDefault();

        //    if (entityToDelete != null)
        //        await VoteService.Delete(entityToDelete);
        //    else
        //        Response.StatusCode = StatusCodes.Status404NotFound;
        //}
    }

}