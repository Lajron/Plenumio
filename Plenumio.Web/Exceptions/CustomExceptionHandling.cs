using Microsoft.AspNetCore.Http;

namespace Plenumio.Web.Middleware {
    public class CustomExceptionHandling(RequestDelegate next) {

        public async Task InvokeAsync(HttpContext context) {
            try {
                await next(context);
            } catch (Exception ex) {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception) {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500; // Internal Server Error
            var response = new {
                Message = "An unexpected error occurred. Please try again later."
            };
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
