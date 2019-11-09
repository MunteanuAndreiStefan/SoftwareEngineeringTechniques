﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeNewsDetectionCache.API.ViewModels.ApplicationUser;
using FakeNewsDetectionCache.Aspects;
using FakeNewsDetectionCache.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeNewsDetectionCache.API.Controllers
{
    [Log]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUsersController : ControllerBase
    {
        protected IApplicationUserService ApplicationUserService;

        public ApplicationUsersController(IApplicationUserService applicationUserService)
        {
            ApplicationUserService = applicationUserService;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var items = await ApplicationUserService.GetAll();
            return new JsonResult(items);
        }

        [HttpPost("{model}")]
        public async Task<JsonResult> GetFiltered(ApplicationUserFilterViewModel model)
        {
            var items = await model.ApplyFilter(await ApplicationUserService.GetAsQueriable());
            return new JsonResult(items);
        }

        [HttpPost]
        public async Task Post(ApplicationUserViewModel model)
        {
            await ApplicationUserService.Add(model.ToEntity());
        }

        [HttpPut]
        public async Task Put(ApplicationUserViewModel model)
        {
            await ApplicationUserService.Update(model.ToEntity());
        }

        [HttpDelete("{Id}")]
        public async Task Delete(int Id)
        {
            var entityToDelete = (await ApplicationUserService.GetByFilter(x => x.Id == Id)).FirstOrDefault();

            if (entityToDelete != null)
                await ApplicationUserService.Delete(entityToDelete);
        }
    }
}