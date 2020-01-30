using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Interworks.API.Interfaces;

namespace Interworks.API.Models {
    
    public class Discount : IPrimaryEntity {

        [Key]
        public Guid id { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }

        public string name { get; set; }
        
        public bool isFixed { get; set; }

        public int priority { get; set; }
        
        public string description { get; set; }
        
        public DateTimeOffset expiresAt { get; set; }
        
        public DateTimeOffset startsAt { get; set; }
        
        public List<User> eligibleUsers { get; set; }

    }

   
}