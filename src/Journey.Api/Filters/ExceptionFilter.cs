using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Journey.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is JourneyException)
            {
                var exception = (JourneyException)context.Exception;
                context.HttpContext.Response.StatusCode = (int)exception.GetStatusCode();

                var response = new ResponseErrorsJson(exception.GetErrorMessages());
                context.Result = new ObjectResult(response);
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = new ResponseErrorsJson([ ResourceErrorMessages.UNKNOWN_ERROR ]);
                context.Result = new ObjectResult(response);
            }
        }
    }
}
