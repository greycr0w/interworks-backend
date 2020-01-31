using System;
using Interworks.API.Interfaces;

namespace Interworks.API.Models {
    public class Order : IPrimaryModel{
        public Guid id { get; set; }
        
        public DateTimeOffset createdAt { get; set; }
        
        public DateTimeOffset? updatedAt { get; set; }
        
        private DateTimeOffset startsAt { get; set; }
        
        public void setStartsAt(DateTimeOffset subscriptionStartsAt) {
            startsAt = subscriptionStartsAt;
        }
        
        public Guid userId { get; set; }
        
        public Guid productId { get; set; }

      
    }
}