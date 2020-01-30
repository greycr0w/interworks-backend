
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Interworks.API.Helpers;
using Interworks.API.Interfaces;
using Interworks.API.Models;
using Interworks.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Interworks.API.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryAsync<User> _userRepository;

        public UserService(IRepositoryAsync<User> userRepository) {
            this._userRepository = userRepository;
        }
        
        public IEnumerable<User> GetAll()
        {
            return _userRepository.find();
        }
    }
}