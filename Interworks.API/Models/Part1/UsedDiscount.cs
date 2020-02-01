using System;

namespace Interworks.API.Models {
    public class UsedDiscount {
        public Guid userId { get; set; }
        
        public virtual User user { get; set; }
        
        public Guid discountId { get; set; }
        
        public virtual Discount discount { get; set; }
    }
}

