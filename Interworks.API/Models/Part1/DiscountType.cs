using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interworks.API.Models {
    
    public class DiscountType {
        [Key]
        public Guid id { get; set; }

        public Guid discountId { get; set; }

        public string? code { get; set; }
        
        public bool automaticallyApplied { get; set; }
        
        public decimal? thresholdAmount { get; set; }

        public List<Discount> discounts { get; set; }
    }

 
}