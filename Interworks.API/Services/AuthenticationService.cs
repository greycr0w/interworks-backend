using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Interworks.API.Helpers;
using Interworks.API.Interfaces;
using Interworks.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Interworks.API.Services {
    public class AuthenticationService : IAuthenticationService{
        
        private readonly IRepositoryAsync<User> _userRepository;
        private readonly AppSettings _appSettings;
        

        public AuthenticationService(IRepositoryAsync<User> userRepository, IOptions<AppSettings> appSettings) {
            this._appSettings = appSettings.Value;
            this._userRepository = userRepository;
        }
        
        public async Task<User> authenticate(string username, string password) {
            var user = await _userRepository.find().Where(a => a.username == username).SingleAsync();
            
            // return null if user not found
            if (user == null)
                return null;

            if (user.password != password) {
                return null;
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }

    }
}