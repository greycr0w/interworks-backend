using System;
using Interworks.API.Interfaces;

namespace Interworks.API.Models
{
    public class User : IPrimaryEntity
    {
        public string firstName { get; set; }
        
        public string lastName { get; set; }
        
        public string username { get; set; }
        
        public string password { get; set; }
        
        public string token { get; set; }
        
        public Guid id { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }
    }
}