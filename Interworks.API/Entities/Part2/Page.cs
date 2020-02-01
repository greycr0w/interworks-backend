using System;
using System.Collections.Generic;
using Interworks.API.Interfaces;

namespace Interworks.API.Entities.Part2 {
    public class Page : IPrimaryModel {
        public Guid id { get; set; }
        
        public string name { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }
        
        public virtual List<Field> fields { get; set; }
    }
}