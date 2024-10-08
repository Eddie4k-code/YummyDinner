using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YummyDinner.Application.Common.Contracts;
using YummyDinner.Application.Common.Contracts.Persistence;
using YummyDinner.Domain.Entities;
using YummyDinner.Application.Services.Authentication.Results;

namespace YummyDinner.Application.Services.Authentication.Queries
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {

        private readonly IJwtTokenCreator _jwtTokenCreator;
        private readonly IUserRepository _userRepository;


        public AuthenticationQueryService(IJwtTokenCreator jwtTokenCreator, IUserRepository _userRepository) {

            this._jwtTokenCreator = jwtTokenCreator;
            this._userRepository = _userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {

            var user = _userRepository.GetUser(email);

            //validate user exists
            
            if (user == null) {
                throw new Exception("Incorrect Email or Password");
            }

            //validate password
            if (user.Password != password) {
                throw new Exception("Incorrect email or password");
            }

             //Create JWT Token
            var token = this._jwtTokenCreator.GenerateToken(user);








            return new AuthenticationResult(user.Id, user.Email, user.FirstName, user.LastName, token);
        }


       
    }
}