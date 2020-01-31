using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Interworks.API.Interfaces;

namespace Interworks.API.Models {
    
    public class Discount : IPrimaryModel {

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
        
        public List<UserDiscounts> userDiscounts { get; set; }        //discount can apply to one or more users

        public Guid productId { get; set; }         //discount involves a product upon which 1 or more users have a discount available for

        
        
        

    }

   
}