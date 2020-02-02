using System;
using System.ComponentModel.DataAnnotations;
using Interworks.API.Interfaces;

namespace Interworks.API.Entities.Part1 {

    public class Country : IPrimaryEntity
    {        
        [Key]
        public Guid id { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }
        public string code { get; set; }

        public string name { get; set; }

        public decimal shippingCost { get; set; }
      
    }

}