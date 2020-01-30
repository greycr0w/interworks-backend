using System.Collections.Generic;
using Interworks.API.Models;

namespace Interworks.API.Interfaces {
    public interface IUserService {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}