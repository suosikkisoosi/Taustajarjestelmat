using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taustajarjestelmat_2
{

    public class ValidateModelAttribute : ActionFilterAttribute
    { 
        private ILogger<ValidateModelAttribute> _logger;
        public ValidateModelAttribute(ILogger<ValidateModelAttribute> logger)
        {
            _logger = logger;
        }
    
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("on validation");
            if (context.ModelState.IsValid == false)
            {
                _logger.LogInformation("Client sent an illegal model");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
