using System;
using System.ComponentModel.DataAnnotations;

namespace Interworks.API.Entities.Part1 {
    public class Template {
        [Key]
        public Guid id { get; set; }

        public string key { get; set; } // onPurchaseApproved, 

        public int type { get; set; } // sms or email

        public string title { get; set; }

        public string body { get; set; }
        
        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset? updatedAt { get; set; }
    }

}