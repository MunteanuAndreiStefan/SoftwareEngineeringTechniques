//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FakeNewsDetectionCache.EntitiesDiagram
{
    using System;
    using System.Collections.Generic;
    
    public partial class NewsArticle
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public Nullable<int> CredibilityScore { get; set; }
    
        public virtual TwitterUser User { get; set; }
    }
}
