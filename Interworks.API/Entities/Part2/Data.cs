using System;
using Interworks.API.Interfaces;

namespace Interworks.API.Entities.Part2 {
    public class Data : IPrimaryModel {
        public Guid id { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }
        
        public string? textbox { get; set; }
        
        public virtual Guid? dropdownSelect { get; set; }
        
        public string? imagePath { get; set; }
        
        public  Guid userId { get; set; }
        
        public virtual User user { get; set; }
        
        public virtual Field field { get; set; }
        
        public  Guid fieldId { get; set; }

    }
}