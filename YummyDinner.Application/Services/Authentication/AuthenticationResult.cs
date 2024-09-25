using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YummyDinner.Application.Services.Authentication
{
    public record AuthenticationResult
    {
         public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Token { get; init; }


        public AuthenticationResult(Guid id, string firstName, string lastName, string email, string Token) {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Token = Token;
        } 

    }
}