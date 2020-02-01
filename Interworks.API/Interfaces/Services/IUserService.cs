using System.Collections.Generic;
using System.Threading.Tasks;
using Interworks.API.Entities;

namespace Interworks.API.Interfaces {
    public interface IUserService {
        IEnumerable<User> getAll();
    }
}