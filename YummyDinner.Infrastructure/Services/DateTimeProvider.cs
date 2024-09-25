using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YummyDinner.Application.Common.Contracts;

namespace YummyDinner.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}