using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Interworks.API.Interfaces;

namespace Interworks.API.Entities.Part1 {
    
    public class Discount : IPrimaryModel {

        [Key]
        public Guid id { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }

        public string name { get; set; }
        
        public string description { get; set; }
        
        public decimal amount { get; set; }
        
        public DateTimeOffset? expiresAt { get; set; }
        
        public DateTimeOffset? startsAt { get; set; }
        
        public bool isFixed { get; set; }

        public int priority { get; set; }
        
        public decimal? thresholdAmount { get; set; }
        
        public string code { get; set; }
        
        public bool isAutomaticallyApplied { get; set; }

        public int? maxUses { get; set; } //maxUses is a discount for all users until certain amount of appliance is met

        public int? maxUsesPerUser { get; set; }
        public virtual List<ProductDiscount> productDiscounts { get; set; }         //discount involves a product upon which 1 or more users have a discount available for
        
        public virtual List<UsedDiscount> usedDiscounts { get; set; }
    }

   
}