using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YummyDinner.Contracts.Authentication
{
    public record LoginRequest
    (
        string FirstName,
        string LastName,
        string Email,
        string Password
    );
}