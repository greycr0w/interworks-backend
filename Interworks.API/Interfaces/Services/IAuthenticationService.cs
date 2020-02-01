using System.Threading.Tasks;
using Interworks.API.Entities;

namespace Interworks.API.Interfaces {
    public interface IAuthenticationService {
        public Task<User> authenticate(string username, string password);
    }
}