using System;
using System.Collections.Generic;
using Interworks.API.Interfaces;

namespace Interworks.API.Models {
    public class Data : IPrimaryModel {
        public Guid id { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }
        
        public string? textbox { get; set; }
        
        public Guid? dropdownSelect { get; set; }
        
        public string? imagePath { get; set; }
        
        public Guid userId { get; set; }
        
        public Guid fieldId { get; set; }

    }
}