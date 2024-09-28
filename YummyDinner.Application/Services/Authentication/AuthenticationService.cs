using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YummyDinner.Application.Common.Contracts;
using YummyDinner.Application.Common.Contracts.Persistence;


namespace YummyDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthService
    {

        private readonly IJwtTokenCreator _jwtTokenCreator;
        private readonly IUserRepository _userRepository;


        public AuthenticationService(IJwtTokenCreator jwtTokenCreator, IUserRepository _userRepository) {

            this._jwtTokenCreator = jwtTokenCreator;
            this._userRepository = _userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {


            return new AuthenticationResult(Guid.NewGuid(), "email", "password", "firstname", "lastname");
        }

        public AuthenticationResult Register(string firstName, string lastName, string password, string email) {
            //Check if user already exists

            //Create User

            //Create JWT Token
            var token = this._jwtTokenCreator.GenerateToken(new Guid(), firstName, lastName);
            
            return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, token);
        }

       
    }
}