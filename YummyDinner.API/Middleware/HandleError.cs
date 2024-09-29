using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YummyDinner.API.Middleware
{
    public class HandleError
    {

        private readonly RequestDelegate _next;
        public HandleError(RequestDelegate next)
        {
            _next = next;

        }


        public async Task Handle(HttpContext context)
        {

            try {

                await _next(context);

            } catch(Exception ex) {

                await context.Response.WriteAsync(ex.Message);

            }

        }
    }
}