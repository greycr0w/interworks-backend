using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Interworks.API.Interfaces;

namespace Interworks.API.Entities.Part2 {
    public class FieldOption : IPrimaryEntity{
        [Key]
        public Guid id { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }
        
        public string value { get; set; }
        public virtual List<Data> datum { get; set; }
        
        public Guid fieldId { get; set; }

        public virtual Field field { get; set; }
    }
}