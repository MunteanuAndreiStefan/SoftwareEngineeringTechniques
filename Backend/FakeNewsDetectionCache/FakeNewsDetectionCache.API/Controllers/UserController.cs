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
    public class UserController : ControllerBase
    {

    protected IUserService UserService;

    public UserController(IUserService userService)
    {
      UserService = userService;
    }

    [HttpGet]
    public async Task<JsonResult> Get()
    {
      var items = await UserService.GetAll();
      return new JsonResult(items);
    }

    [HttpPost]
    public async Task Post(UserViewModel model)
    {
      await UserService.Add(model.ToEntity());
    }

  }
}