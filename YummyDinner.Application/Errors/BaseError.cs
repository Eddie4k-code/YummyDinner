using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YummyDinner.Application.Errors
{   

    /* Blueprint for all custom exceptions created */
    public class BaseError : Exception
    {

        public readonly int StatusCode;

        public BaseError(string message, int statusCode) : base(message) { 
            this.StatusCode = statusCode;
        }
        
    }
}