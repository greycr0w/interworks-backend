using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interworks.API.Models {
    
    public class DiscountRules {
        [Key]
        public Guid id { get; set; }

        public Guid discountId { get; set; }
        
        public decimal amount { get; set; }
        
        public decimal? thresholdAmount { get; set; }

        public int? maxUses { get; set; }
        
        public List<Discount> discounts { get; set; }
    }

 
}