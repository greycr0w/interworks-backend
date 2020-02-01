using System;
using Interworks.API.Interfaces;

namespace Interworks.API.Models {
    public class FieldOption : IPrimaryModel{
        public Guid id { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }
        
        public Guid fieldId { get; set; }
        
        public string value { get; set; }
    }
}