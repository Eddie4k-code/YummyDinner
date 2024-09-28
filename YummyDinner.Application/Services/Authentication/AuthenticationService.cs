using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YummyDinner.Application.Common.Contracts;
using YummyDinner.Application.Common.Contracts.Persistence;
using YummyDinner.Domain.Entities;


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

            var user = _userRepository.GetUser(email);

            //validate user exists
            
            if (user == null) {
                throw new Exception("Incorrect Email or Password");
            }

            //validate password
            if (user.Password != password) {
                throw new Exception("Incorrect email or password");
            }








            return new AuthenticationResult(Guid.NewGuid(), "email", "password", "firstname", "lastname");
        }

        public AuthenticationResult Register(string firstName, string lastName, string password, string email) {
            //Check if user already exists
            if (this._userRepository.GetUser(email) != null) {
                throw new Exception("User already exists.");
            }

            //Create User

            var user = new User{
                FirstName = firstName,
                LastName = lastName,
                Password = password,
                Email = email
            };

            this._userRepository.Add(user);

            //Create JWT Token
            var token = this._jwtTokenCreator.GenerateToken(user.Id, user.FirstName, user.LastName);
            
            return new AuthenticationResult(user.Id, user.FirstName, user.LastName, user.Email, token);
        }

       
    }
}