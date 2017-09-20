using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taustajarjestelmat_2.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;
       public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            bool failed = false;
            try
            {
                await _next(context);
            }
            catch(NotFoundException e)
            {
                context.Response.StatusCode = 404;
                failed = true;
            }
            if(failed)
            {
                context.Response.WriteAsync("Player not found");
            }
        }
    }
}
   

