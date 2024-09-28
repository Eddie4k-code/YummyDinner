using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YummyDinner.Application.Common.Contracts.Persistence;
using YummyDinner.Domain.Entities;

namespace YummyDinner.Infrastructure.Persistence
{

    /* Concrete implementation of a user repository that will interact with database */
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public User? GetUser(string email)
        {
            throw new NotImplementedException();
        }
    }
}