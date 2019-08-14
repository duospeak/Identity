using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace Microsoft.AspNetCore.Mvc.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;

        public HttpGlobalExceptionFilter(ILogger<HttpGlobalExceptionFilter> logger)
            => _logger = logger.NotNull(nameof(logger));

        public void OnException(ExceptionContext context)
        {

            if (context.ExceptionHandled)
            {
                return;
            }

            if (context.Exception is DomainException error)
            {
                var problem = new ProblemDetails()
                {
                    Detail = error.Message,
                    Title = "Your request cannot be handling",
                    Status = 400,
                    Extensions =
                    {
                        { "code",error.ErrorCode }
                    },
                    Type = "https://tools.ietf.org/html/rfc7807",
                };

                var enumerator = error.Data.GetEnumerator();

                while (enumerator.MoveNext() && enumerator.Key is string key)
                {
                    problem.Extensions.Add(key, enumerator.Value);
                }

                //error.Data

                context.Result = new BadRequestObjectResult(StatusCodes.Status400BadRequest)
                {
                    Value = problem
                };

                context.ExceptionHandled = true;

                _logger.LogWarning(error.ErrorCode?.GetHashCode() ?? 0, error, problem.Detail);

                return;
            }

            _logger.LogError(context.Exception, context.Exception.Message);

            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);

            context.ExceptionHandled = true;
        }
    }
}
