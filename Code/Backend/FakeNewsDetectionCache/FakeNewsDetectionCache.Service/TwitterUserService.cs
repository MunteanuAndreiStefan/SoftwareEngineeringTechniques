using FakeNewsDetectionCache.Entities.Models;
using FakeNewsDetectionCache.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeNewsDetectionCache.Service
{
  public class TwitterUserService:CrudService<TwitterUser,Repository>,ITwitterUserService
  {
    public TwitterUserService(Repository dbContext) : base(dbContext)
    {

    }
  }
}
