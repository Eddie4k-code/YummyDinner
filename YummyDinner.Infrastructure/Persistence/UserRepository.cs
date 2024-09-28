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

        private readonly List<User> _users = new List<User>();

        public void Add(User user)
        {
            this._users.Add(user);
        }

        public User? GetUser(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }
    }
}