﻿using FakeNewsDetectionCache.Entities.Models;
using FakeNewsDetectionCache.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FakeNewsDetectionCache.Service
{
    public class ApplicationUserService: CrudService<ApplicationUser, Repository>, IApplicationUserService
    {
        public ApplicationUserService(Repository dbContext) : base(dbContext)
        {

        }

        public async Task<bool> IsUsernameUnique(string username)
        {
            return (await GetByFilter(x => x.Username == username)).Count == 0;
        }
    }
}
