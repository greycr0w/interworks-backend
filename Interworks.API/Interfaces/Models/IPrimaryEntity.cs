using System;

namespace Interworks.API.Interfaces {
    public interface IPrimaryEntity {
        Guid id { get; set; }

        DateTimeOffset createdAt { get; set; }
         
        DateTimeOffset? updatedAt { get; set; }
    }
}