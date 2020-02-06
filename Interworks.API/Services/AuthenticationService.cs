using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Interworks.API.Entities;
using Interworks.API.Helpers;
using Interworks.API.Interfaces;
using Interworks.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Interworks.API.Services {
    public class AuthenticationService : IAuthenticationService{
        
        private readonly UserRepository _userRepository;
        private readonly AppSettings _appSettings;
        
        //TODO: this is a very fast implementation of Identity to be able to have user context
        //I should have a different repository for Accounts and not use the userRepository
        
        public AuthenticationService(UserRepository userRepository, IOptions<AppSettings> appSettings) {
            this._appSettings = appSettings.Value;
            this._userRepository = userRepository;
        }
        
        public async Task<User> authenticate(string username, string password) {
            var user = await _userRepository.find().Where(a => a.username == username).SingleAsync();
            
            if (user == null)
                return null;

            if (user.password != password) {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler(); //generate jwt since auth was successful
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