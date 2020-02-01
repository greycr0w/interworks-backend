using System;

namespace Interworks.API.Models {
 
    public class ProductDiscount {
        
        public Guid productId { get; set; } 
        
        public Product product { get; set; }
        
        public Guid discountId { get; set; }
        
        public Discount discount { get; set; }
    }
}