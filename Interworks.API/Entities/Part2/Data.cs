using System;
using System.ComponentModel.DataAnnotations;
using Interworks.API.Interfaces;

namespace Interworks.API.Entities.Part2 {
    public class Data : IPrimaryEntity {
        [Key]
        public Guid id { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }
        
        public string textbox { get; set; }
        
        public  Guid? fieldOptionId { get; set; }
        
        public virtual FieldOption fieldOption { get; set; }
        
        public string imagePath { get; set; } //simple image element addition

        public  Guid userId { get; set; } //implemented
        
        public virtual User user { get; set; } //implemented
        
        public virtual Field field { get; set; } //implemented
        
        public  Guid fieldId { get; set; } //implemented

    }
}