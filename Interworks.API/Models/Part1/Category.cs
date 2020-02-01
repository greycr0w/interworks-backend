using System;
using System.Collections.Generic;
using Interworks.API.Interfaces;

namespace Interworks.API.Models {
    public class Category : IPrimaryModel{
        public Guid id { get; set; }
        
        public string name { get; set; }
        
        public virtual List<Product> products { get; set; }
        public DateTimeOffset createdAt { get; set; }
        
        public DateTimeOffset? updatedAt { get; set; }
        
    }
}