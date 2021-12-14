using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http;

namespace PFEBackend
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is RepositoryException exception)
            {
                context.Result = new ObjectResult(exception.Message)
                {
                    StatusCode = (int) exception.Response.StatusCode,
                };
                context.ExceptionHandled = true;
            } else if (context.Exception is HttpResponseException exceptionHTTP)
            {
                context.Result = new ObjectResult("An error as occured")
                {
                    StatusCode = (int)exceptionHTTP.Response.StatusCode,
                };
                context.ExceptionHandled = true;
            } else if (context.Exception is Exception exceptionErreur)
            {
                context.Result = new ObjectResult(exceptionErreur.Message)
                {
                    StatusCode = (int)StatusCodes.Status500InternalServerError,
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
