using System;
using System.Collections.Generic;
using Interworks.API.Interfaces;

namespace Interworks.API.Entities.Part2 {
    public class Field : IPrimaryModel {
        public Guid id { get; set; }
        
        public string name { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }
        
        public virtual List<FieldOption> fieldOptions { get; set; }

        public virtual List<Data> data { get; set; }

        public Guid pageId { get; set; }

        public virtual Page page { get; set; }
    }
}