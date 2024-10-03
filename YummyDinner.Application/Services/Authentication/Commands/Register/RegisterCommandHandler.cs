using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using YummyDinner.Application.Common.Contracts;
using YummyDinner.Application.Common.Contracts.Persistence;
using YummyDinner.Application.Services.Authentication.Results;
using YummyDinner.Domain.Entities;

namespace YummyDinner.Application.Services.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {

        private readonly IJwtTokenCreator _jwtTokenCreator;
        private readonly IUserRepository _userRepository;


        public RegisterCommandHandler(IJwtTokenCreator jwtTokenCreator, IUserRepository userRepository)
        {
            this._jwtTokenCreator = jwtTokenCreator;
            this._userRepository = userRepository;
        }

        
        public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
             //Check if user already exists
            if (this._userRepository.GetUser(request.email) != null) {
                throw new Exception("User already exists.");
            }

            //Create User

            var user = new User{
                FirstName = request.firstName,
                LastName = request.lastName,
                Password = request.password,
                Email = request.email
            };

            this._userRepository.Add(user);

            //Create JWT Token
            var token = this._jwtTokenCreator.GenerateToken(user);
            
            return new AuthenticationResult(user.Id, user.FirstName, user.LastName, user.Email, token);
        }
    }

}