using System;
using System.ComponentModel.DataAnnotations;

namespace Interworks.API.Models {
    
    public class Discount {
        [Key]
        public int id { get; set; }
        
        public string name { get; set; }
        
        public bool isFixed { get; set; }

        public int priority { get; set; }
        
        public string description { get; set; }
        
        public DateTimeOffset expiresAt { get; set; }
        
        public DateTimeOffset startsAt { get; set; }
        
        public DateTimeOffset createdAt { get; set; }
    }

   
}