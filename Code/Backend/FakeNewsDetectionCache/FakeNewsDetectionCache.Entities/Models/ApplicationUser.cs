using System;
using System.Collections.Generic;
using System.Text;

namespace FakeNewsDetectionCache.Entities.Models
{
    public class ApplicationUser:Entity
    {

        //public int Id { get; set; }
        public string Username { get; set; }
        public int? CredibilityScore { get; set; }

    }
}
