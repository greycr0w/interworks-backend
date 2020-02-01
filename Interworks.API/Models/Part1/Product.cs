using System;
using System.Collections.Generic;
using Interworks.API.Interfaces;

namespace Interworks.API.Models {
    public class Product : IPrimaryModel {
        
        public Guid id { get; set; }
        
        public string name { get; set; }
        
        public decimal price { get; set; }
        
        public bool isSubscription { get; set; }
        
        public string description { get; set; }
        
        public Guid categoryId { get; set; }
        
        public int validityDays { get; set; }
        public virtual Category category { get; set; } 

        public DateTimeOffset createdAt { get; set; }
        
        public DateTimeOffset? updatedAt { get; set; }

        public List<ProductDiscount> productDiscounts { get; set; }
        
        
        
    }
}