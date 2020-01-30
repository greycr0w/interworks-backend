using Interworks.API.Models;
using Interworks.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Interworks.API.Controllers {
    
    [Authorize]
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public class AuthenticationController : ControllerBase {

        private AuthenticationService _authenticationService;

        public AuthenticationController(AuthenticationService authenticationService) {

            this._authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model) {
            var user = _authenticationService.authenticate(model.username, model.password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}