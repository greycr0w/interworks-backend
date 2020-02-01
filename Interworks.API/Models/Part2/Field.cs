using System;
using System.Collections.Generic;
using Interworks.API.Interfaces;

namespace Interworks.API.Models {
    public class Field : IPrimaryModel {
        public Guid id { get; set; }
        
        public string name { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }
        
        public List<FieldOption> fieldOptions { get; set; }

        public List<Data> data { get; set; }
        
        public Guid pageId { get; set; }

    }
}