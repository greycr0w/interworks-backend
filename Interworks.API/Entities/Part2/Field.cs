using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Interworks.API.Interfaces;

namespace Interworks.API.Entities.Part2 {
    public enum FieldType {
        TEXTBOX = 0,
        IMAGE = 1
    }
    public class Field : IPrimaryEntity {
        [Key]
        public Guid id { get; set; }
        
        public string name { get; set; }
        
        public FieldType type { get; set; } 
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }
        
        public virtual List<FieldOption> fieldOptions { get; set; }
        public virtual List<Data> datum { get; set; }

        public Guid pageId { get; set; } //implemented
        public virtual Page page { get; set; } //implemented
    }
}