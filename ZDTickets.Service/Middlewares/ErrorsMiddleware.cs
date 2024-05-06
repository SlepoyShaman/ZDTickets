using System.ComponentModel.DataAnnotations;

namespace ZDTickets.Service.Middlewares
{
    public static class CatchExceptionExtention
    {
        public static IApplicationBuilder UseExceptionToHttpResponse(this IApplicationBuilder app) =>
            app.UseMiddleware<ErrorMiddleware>();
    }
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (KeyNotFoundException e)
            {
                httpContext.Response.StatusCode = 404;
                await Throw(httpContext, e);
            }
            catch (ArgumentException e)
            {
                httpContext.Response.StatusCode = 400;
                await Throw(httpContext, e);
            }
            catch (ValidationException e)
            {
                httpContext.Response.StatusCode = 400;
                await Throw(httpContext, e);
            }
            catch (Exception e)
            {
                httpContext.Response.StatusCode = 500;
                await Throw(httpContext, e);
            }
        }

        private static async Task Throw(HttpContext httpContext, Exception e, string? Content = null)
        {
            var responceBody = new ResponseBody(e, Content);
            httpContext.Response.ContentType = "application/json; charset=utf-8";
            await httpContext.Response.WriteAsync(responceBody.ToString());
        }
    }
}
