using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using YummyDinner.Domain.Entities;

namespace YummyDinner.Application.Common.Contracts.Persistence
{
    public interface IUserRepository
    {

        User? GetUser(string email);
        void Add(User user);


    }
}