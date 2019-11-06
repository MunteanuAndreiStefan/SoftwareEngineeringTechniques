﻿using FakeNewsDetectionCache.Entities.Models;
using FakeNewsDetectionCache.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeNewsDetectionCache.Service
{
    public class ApplicationUserService: CrudService<ApplicationUser, Repository>, IApplicationUserService
    {
        public ApplicationUserService(Repository dbContext) : base(dbContext)
        {

        }
    }
}