using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YummyDinner.Application.Common.Contracts
{
    public interface IJwtTokenCreator
    {
        string GenerateToken(Guid Id, string firstName, string lastName);
    }
}