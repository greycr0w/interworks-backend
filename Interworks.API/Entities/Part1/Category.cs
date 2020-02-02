using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Interworks.API.Interfaces;

namespace Interworks.API.Entities.Part1 {
    public class Category : IPrimaryEntity{
        
        [Key]
        public Guid id { get; set; }
        
        public string name { get; set; }
        
        public virtual List<Product> products { get; set; }
        public DateTimeOffset createdAt { get; set; }
        
        public DateTimeOffset? updatedAt { get; set; }
        
    }
}