using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Services;
using System.Threading.Tasks;

namespace WebApiSite
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        
        public RequestLoggerMiddleware(RequestDelegate next)
        {
            
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRateServices rateServices)
        {
            Rating rating = new Rating();
            rating.Host= httpContext.Request.Headers.Host;
            rating.Method = httpContext.Request.Method;
            rating.Path = httpContext.Request.Path;
            rating.Referer = httpContext.Request.Headers.Referer;
         
            rating.UserAgent = httpContext.Request.Headers.UserAgent;
            rating.RecordDate = DateTime.Now;

            await  rateServices.InsertRating(rating);
             await _next(httpContext);
        }
    }

    

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
}
