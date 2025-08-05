using communication.Responses.Exception;
using Exception;
using Exception.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace hometask.api.Filters
{
    public class ExceptionFilters : IExceptionFilter
    {
        public void OnException(ExceptionContext context) 
        {
            if(context.Exception is ApiException)
            {
                HandleException(context);
            }
            else
            {
                UnknowException(context);
            }
        }

        private void HandleException(ExceptionContext context)
        {
            if (context.Exception is RegisterException RegisterException)
            {
                var errors = RegisterException.Errors;

                context.HttpContext.Response.StatusCode =StatusCodes.Status400BadRequest;
                context.Result = new ObjectResult(errors);
            }
            if (context.Exception is LoginException LoginException)
            {
                var errors = LoginException.Errors;

                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new ObjectResult(errors);
            }
        }

        private void UnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(ResourceErrorMessages.UNKNOW_ERROR);
        }
    }
}
