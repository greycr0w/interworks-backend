using System;

namespace Interworks.API.Interfaces {
    public interface ISoftDeletePrimaryEntity : IPrimaryEntity {
        public DateTimeOffset deletedAt { get; set; }
    }
}