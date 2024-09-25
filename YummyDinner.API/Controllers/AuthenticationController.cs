
using Microsoft.AspNetCore.Mvc;
using YummyDinner.Application.Services.Authentication;
using YummyDinner.Contracts.Authentication;


namespace YummyDinner.API.Controllers
{

    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private IAuthService _authenticationService;

        public AuthenticationController(IAuthService authenticationService) {
            this._authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request) {
            
            var authResult = this._authenticationService.Register(
                request.Email, request.Password, request.FirstName, request.LastName
            );

            return Ok(authResult);
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequest request) {

            var authResult = this._authenticationService.Login(
                request.Email, request.Password
            );
            
            return Ok(authResult);
        }

    }
}