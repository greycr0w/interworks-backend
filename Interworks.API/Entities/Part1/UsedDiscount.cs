using System;

namespace Interworks.API.Entities.Part1 {
    public class UsedDiscount {
        public Guid userId { get; set; }
        
        public virtual User user { get; set; }
        
        public Guid discountId { get; set; }
        
        public virtual Discount discount { get; set; }
    }
}

