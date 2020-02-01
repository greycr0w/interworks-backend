using System;
using Interworks.API.Interfaces;

namespace Interworks.API.Models {
    public class Order : IPrimaryModel{
        public Guid id { get; set; }
        
        public DateTimeOffset createdAt { get; set; }
        
        public DateTimeOffset? updatedAt { get; set; }
        
        public DateTimeOffset startsAt { get; set; }
        
        public DateTimeOffset endsAt { get; set; }

        public int cycle { get; set; } //every number of months to charge the amount that this order was ordered with
        
        public decimal amount { get; set; } //charge this amount every cycle
        
        public int validityDays { get; set; } //validity of order in days from starts to endsAt how many days
        
        public int validityMonths { get; set; } //validity of product in months 
        
        public string description { get; set; }

        public Guid userId { get; set; }
        
        public Guid productId { get; set; }

      
    }
}