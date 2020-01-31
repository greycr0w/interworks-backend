using System;

namespace Interworks.API.Interfaces {
    public interface IPrimaryModel {
        
        Guid id { get; set; }

        DateTimeOffset createdAt { get; set; }
         
        DateTimeOffset? updatedAt { get; set; }
    }
}