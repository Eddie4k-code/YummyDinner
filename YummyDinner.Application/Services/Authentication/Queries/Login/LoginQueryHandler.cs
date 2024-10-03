using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using YummyDinner.Application.Common.Contracts;
using YummyDinner.Application.Common.Contracts.Persistence;
using YummyDinner.Application.Services.Authentication.Queries.Login;
using YummyDinner.Application.Services.Authentication.Results;
using YummyDinner.Domain.Entities;

namespace YummyDinner.Application.Services.Authentication.Commands.Register
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {

        private readonly IJwtTokenCreator _jwtTokenCreator;
        private readonly IUserRepository _userRepository;


        public LoginQueryHandler(IJwtTokenCreator jwtTokenCreator, IUserRepository userRepository)
        {
            this._jwtTokenCreator = jwtTokenCreator;
            this._userRepository = userRepository;
        }

        
        public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
             var user = _userRepository.GetUser(request.email);

            //validate user exists
            
            if (user == null) {
                throw new Exception("Incorrect Email or Password");
            }

            //validate password
            if (user.Password != request.password) {
                throw new Exception("Incorrect email or password");
            }

             //Create JWT Token
            var token = this._jwtTokenCreator.GenerateToken(user);








            return new AuthenticationResult(user.Id, user.Email, user.FirstName, user.LastName, token);
        }
    }

}