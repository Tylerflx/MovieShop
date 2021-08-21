using ApplicationCore.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShopMVC.Infrastructure
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionMiddleware> _logger;

        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Exception Middleware Beginning");
            try
            {
                //when everything is good
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //when any exception happend then handle here
                //MOvieService => Exception
                _logger.LogError($"Catching the exception in middleware{ex}");
                await HandleException(httpContext, ex);
            }
        }
        private async Task HandleException(HttpContext httpContext, Exception ex)
        {
            //catch the actual type of exception , set the http status code
            //log the details

            switch (ex)
            {
                case ConflictException _: //underscore is checking for the type
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case NotFoundException _:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            //Using Serilog
            // log URL,  IP Address, Controller/Action, DateTime, StackTrace, Error Message, UserId,
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("./Log/log.txt")
                .CreateLogger();

            var newLog = new {
                ControllerAction = httpContext.Request.Path.ToUriComponent(), //Controller and Action
                UserIsAuthenticated = httpContext.User.Identity.IsAuthenticated,
                UserId = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                Message = ex.Message,
                Created = DateTime.Now,
                StactTrade = ex.StackTrace
                //IpAddress = httpContext.Connection.RemoteIpAddress.ToString()
            };

            Log.Information("{newLog} \n END", newLog, DateTime.Now);

            Log.CloseAndFlush();
            //display a friendly page to user
            httpContext.Response.Redirect("/Home/Error");
            await Task.CompletedTask;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
