using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using People.Api.Entities.Exceptions;
using People.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace People.Api.ExceptionMiddleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public GlobalExceptionHandler(RequestDelegate next,
            ILogger<GlobalExceptionHandler> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured in {httpContext.Request.Path} {httpContext.Request.Method}");
                logger.LogError(ex.Message);
                logger.LogError(ex.StackTrace);

                Type exceptionType = ex.GetType();
                if (exceptionType == typeof(ValidationException))
                {
                    await HandleValidationExceptionAsync(httpContext,
                        ex as ValidationException);
                }
                else if (exceptionType == typeof(NotFoundException))
                {
                    await HandleNotFoundExceptionAsync(httpContext,
                        ex as NotFoundException);
                }
                else
                {
                    await HandleExceptionAsync(httpContext,
                        ex);
                }
            }
        }

        private async Task HandleValidationExceptionAsync(HttpContext httpContext,
            ValidationException exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            OutputValidationException outputValidationException = new OutputValidationException(exception);
            await httpContext.Response.WriteAsync(outputValidationException.ToString());
        }

        private async Task HandleNotFoundExceptionAsync(HttpContext httpContext,
            NotFoundException exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            OutputNotFoundException outputNotFoundException = new OutputNotFoundException(exception);
            await httpContext.Response.WriteAsync(outputNotFoundException.ToString());
        }

        private async Task HandleExceptionAsync(HttpContext httpContext,
            Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            OutputException outputException = new OutputException(exception);
            await httpContext.Response.WriteAsync(outputException.ToString());
        }
    }
}
