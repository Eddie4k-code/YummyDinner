
using Microsoft.AspNetCore.Mvc;
using YummyDinner.Application.Services.Authentication;
using YummyDinner.Application.Services.Authentication.Commands;
using YummyDinner.Application.Services.Authentication.Queries;
using YummyDinner.Contracts.Authentication;


namespace YummyDinner.API.Controllers
{

    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;

        public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService) {
            this._authenticationCommandService = authenticationCommandService;
            this._authenticationQueryService = authenticationQueryService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request) {
            
            var authResult = this._authenticationCommandService.Register(
                request.Email, request.Password, request.FirstName, request.LastName
            );

            return Ok(authResult);
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequest request) {

            var authResult = this._authenticationQueryService.Login(
                request.Email, request.Password
            );
            
            return Ok(authResult);
        }

    }
}