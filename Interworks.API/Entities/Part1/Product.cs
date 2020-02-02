using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Interworks.API.Interfaces;

namespace Interworks.API.Entities.Part1 {
    public class Product : IPrimaryEntity {
        //subscription
        [Key]
        public Guid id { get; set; }
        
        public string name { get; set; }
        public decimal price { get; set; }
        
        public bool isSubscription { get; set; }
        
        public string description { get; set; }
        
        public int monthsCycle { get; set; } //payment for the subscription will be done every cycle = 6 months
        
        public int monthsActive { get; set; } //the subscription is for 12 months
        
        public Guid categoryId { get; set; }

        public virtual Category category { get; set; } 

        public DateTimeOffset createdAt { get; set; }
        
        public DateTimeOffset? updatedAt { get; set; }

        public DateTimeOffset? deletedAt { get; set; }

        public virtual List<ProductDiscount> productDiscounts { get; set; }
        
        public virtual List<Order> productOrders { get; set; }
        
        
        
    }
}