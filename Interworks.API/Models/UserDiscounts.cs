using System;

namespace Interworks.API.Models {
 
    public class UserDiscounts {
        
        public Guid userId { get; set; } 
        public User user { get; set; }
        public Guid discountId { get; set; }
        public Discount discount { get; set; }
    }
}