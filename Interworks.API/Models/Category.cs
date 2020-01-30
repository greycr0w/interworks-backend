using System;
using Interworks.API.Interfaces;

namespace Interworks.API.Models {
    public class Category : IPrimaryEntity{
        public Guid id { get; set; }
        
        public DateTimeOffset createdAt { get; set; }
        
        public DateTimeOffset? updatedAt { get; set; }
        
    }
}