using System;
using System.ComponentModel.DataAnnotations;
using Interworks.API.Interfaces;

namespace Interworks.API.Entities.Part1 {
    public class Order : IPrimaryEntity{
        [Key]
        public Guid id { get; set; }
        
        public DateTimeOffset createdAt { get; set; }
        
        public DateTimeOffset? updatedAt { get; set; }
        
        public DateTimeOffset startsAt { get; set; }
        
        public DateTimeOffset endsAt { get; set; }

        public int? monthsCycle { get; set; } //every number of months to charge the amount that this order was ordered with OR IT might have been payed immediately for X amount of time
        
        public decimal amount { get; set; } //charge this amount every cycle
        
        public int validityDays { get; set; } //validity of order in days from starts to endsAt how many days
        
        public int validityMonths { get; set; } //validity of product in months 
        
        public string description { get; set; }
        
        public Guid userId { get; set; }
        
        public virtual User user { get; set; }
        
        public Guid productId { get; set; }
        
        public virtual Product product { get; set; }

      
    }
}