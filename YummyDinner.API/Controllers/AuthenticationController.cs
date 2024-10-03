
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyDinner.Application.Services.Authentication;
using YummyDinner.Application.Services.Authentication.Commands;
using YummyDinner.Application.Services.Authentication.Commands.Register;
using YummyDinner.Application.Services.Authentication.Queries;
using YummyDinner.Application.Services.Authentication.Queries.Login;
using YummyDinner.Contracts.Authentication;


namespace YummyDinner.API.Controllers
{

    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;

        public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService) {
            this._authenticationCommandService = authenticationCommandService;
            this._authenticationQueryService = authenticationQueryService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request) {
            
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password); 


            var authResult = await this._mediator.Send(command);

            // var authResult = this._authenticationCommandService.Register(
            //     request.Email, request.Password, request.FirstName, request.LastName
            // );

            return Ok(authResult);
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequest request) {

            // var authResult = this._authenticationQueryService.Login(
            //     request.Email, request.Password
            // );
            var query = new LoginQuery(request.Email, request.Password);
            var authResult = this._mediator.Send(query);
            
            return Ok(authResult);
        }

    }
}