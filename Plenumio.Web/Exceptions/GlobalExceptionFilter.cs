using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Plenumio.Core.Exceptions;
using System.Net;

namespace Plenumio.Web.Exceptions {
    public sealed class GlobalExceptionFilter(
            ProblemDetailsFactory problemFactory,
            ILogger<GlobalExceptionFilter> logger
        ) : IExceptionFilter {

        public void OnException(ExceptionContext context) {
            if (context.Exception is not ServiceException se) {
                return;
            }

            var (status, title) = Map(se);

            logger.LogInformation(context.Exception, "Handled {ExceptionType}", se.GetType().Name);

            if (WantsJson(context.HttpContext.Request)) {
                var problem = problemFactory.CreateProblemDetails(
                    context.HttpContext,
                    statusCode: status,
                    title: title,
                    detail: se.Message,
                    type: $"https://httpstatuses.com/{status}"
                );
                problem.Extensions["traceId"] = context.HttpContext.TraceIdentifier;

                if (se is ValidationException vex) {
                    if (vex.Errors.Count != 0)
                        problem.Extensions["errors"] = vex.Errors;
                }

                context.Result = new ObjectResult(problem) {
                    StatusCode = status
                };
            } else {
                var vd = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary()) {
                    ["Title"] = title,
                    ["Detail"] = se.Message,
                    ["StatusCode"] = status,
                    ["TraceId"] = context.HttpContext.TraceIdentifier
                };

                if (se is ValidationException vex) {
                    vd["ValidationErrors"] = vex.Errors;
                }

                context.Result = new ViewResult {
                    ViewName = "~/Views/Error/Error.cshtml",
                    ViewData = vd,
                    StatusCode = status
                };
            }

            context.ExceptionHandled = true;
        }

        private static (int status, string title) Map(ServiceException ex) =>
            ex switch {
                ValidationException => (StatusCodes.Status400BadRequest, "Validation failed"),
                ConflictException => (StatusCodes.Status409Conflict, "Conflict"),
                NotFoundException => (StatusCodes.Status404NotFound, "Resource not found"),
                UnauthorizedException => (StatusCodes.Status401Unauthorized, "Unauthorized"),
                ForbiddenException => (StatusCodes.Status403Forbidden, "Forbidden"),
                _ => (StatusCodes.Status400BadRequest, "Request failed")
            };

        private static bool WantsJson(HttpRequest req) {
            var isAjax = req.Headers.TryGetValue("X-Requested-With", out var v)
                         && v == "XMLHttpRequest";
            var accept = req.Headers.Accept.ToString();
            return isAjax || accept.Contains("application/json", StringComparison.OrdinalIgnoreCase);
        }
    }
}
