﻿using FakeNewsDetectionCache.Entities.Models;
using FakeNewsDetectionCache.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeNewsDetectionCache.Service
{
  public class UserService:CrudService<TwitterUser,Repository>,IUserService
  {
    public UserService(Repository dbContext) : base(dbContext)
    {

    }
  }
}
