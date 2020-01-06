using FakeNewsDetectionCache.Entities.Models;
using FakeNewsDetectionCache.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeNewsDetectionCache.Service
{
    public class VoteService : CrudService<Vote, Repository>, IVoteService
    {
        public VoteService(Repository dbContext) : base(dbContext)
        {

        }
    }
}
