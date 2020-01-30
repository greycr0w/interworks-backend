using System;
using Interworks.API.Interfaces;

namespace Interworks.API.Models {
    public class Category : IPrimaryEntity{
        public Guid id { get; set; }
        
        public DateTimeOffset created_at { get; set; }
        
        public DateTimeOffset? updated_at { get; set; }
        
    }
}