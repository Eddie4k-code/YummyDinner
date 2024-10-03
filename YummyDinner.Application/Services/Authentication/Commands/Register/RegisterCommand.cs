using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using YummyDinner.Application.Services.Authentication.Results;

namespace YummyDinner.Application.Services.Authentication.Commands.Register
{

    /* Command used to register */
    public record RegisterCommand
    (
        string firstName,
        string lastName,
        string email,
        string password
    ) : IRequest<AuthenticationResult>;
}