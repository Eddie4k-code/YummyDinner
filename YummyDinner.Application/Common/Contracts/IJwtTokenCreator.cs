using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YummyDinner.Domain.Entities;

namespace YummyDinner.Application.Common.Contracts
{
    public interface IJwtTokenCreator
    {
        string GenerateToken(User user);
    }
}