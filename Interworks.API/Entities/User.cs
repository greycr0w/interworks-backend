using System;
using System.Collections.Generic;
using Interworks.API.Entities.Part1;
using Interworks.API.Entities.Part2;
using Interworks.API.Interfaces;

namespace Interworks.API.Entities
{
    public class User : IPrimaryModel
    {
        public Guid id { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }
        
        public string firstName { get; set; }
        
        public string lastName { get; set; }
        
        public string username { get; set; }
        
        public string password { get; set; }
        
        public string token { get; set; }
        
        public string phone { get; set; }

        public int? countryId { get; set; }
        
        public virtual Country country { get; set; }
        
        public string city { get; set; }

        public string address_line { get; set; }

        public string zip_code { get; set; }

        public virtual List<UsedDiscount> usedDiscounts { get; set; }
        
        public virtual List<Order> userOrders { get; set; }
        
        public virtual List<Data> datum { get; set; }
        
    }
}