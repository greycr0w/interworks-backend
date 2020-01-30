using System;

namespace Interworks.API.Interfaces {
    public interface IPrimaryEntity {
        
        Guid id { get; set; }

        DateTimeOffset created_at { get; set; }
         
        DateTimeOffset? updated_at { get; set; }
    }
}