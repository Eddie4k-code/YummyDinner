using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YummyDinner.Application.Services.Authentication
{
    public interface IAuthService
    {
        AuthenticationResult Login(string email, string password);

        AuthenticationResult Register(string firstName, string lastName, string email, string password);
    
    }
}