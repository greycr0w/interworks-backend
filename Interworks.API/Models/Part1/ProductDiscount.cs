using System;

namespace Interworks.API.Models {
 
    public class ProductDiscount {
        
        public Guid productId { get; set; } 
        
        public virtual Product product { get; set; }
        
        public Guid discountId { get; set; }
        
        public virtual Discount discount { get; set; }
    }
}