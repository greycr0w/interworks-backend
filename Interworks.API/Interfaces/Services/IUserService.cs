using System.Collections.Generic;
using System.Threading.Tasks;
using Interworks.API.Models;

namespace Interworks.API.Interfaces {
    public interface IUserService {
        IEnumerable<User> getAll();
    }
}