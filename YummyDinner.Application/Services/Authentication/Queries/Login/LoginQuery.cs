using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using YummyDinner.Application.Services.Authentication.Results;

namespace YummyDinner.Application.Services.Authentication.Queries.Login
{

    /* query used to Login */
    public record LoginQuery
    (
        string email,
        string password
    ) : IRequest<AuthenticationResult>;
}