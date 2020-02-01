using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Interworks.API.Services;
using System.Linq;
using Interworks.API.Interfaces;

namespace Interworks.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService) {
            _userService = userService;
        }

      

        [HttpGet]
        public IActionResult GetAll() {
            var users = _userService.getAll();
            return Ok(users);
        }
    }
}
