using System.Net;
using DomainLayer.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Shared.ErrorModels;

namespace E_Commerce.Web.Controllers
{
    public class CustomExceptionMiddleWare
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleWare> _logger;

        public CustomExceptionMiddleWare(RequestDelegate next, ILogger<CustomExceptionMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
                await HandleNotFoundEndPointAsync(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandeleExceptionAsync(context, ex);
            }
        }

        private static async Task HandeleExceptionAsync(HttpContext context, Exception ex)
        {
            //Set status code for the response
            context.Response.StatusCode = ex switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            //Set Content type for the response
            context.Response.ContentType = "application/json";

            //Set response Object
            var ErrorToReturn = new ErrorToReturn()
            {
                StatusCode = context.Response.StatusCode,
                ErrorMessage = ex.Message
            };

            //Return Object as Json
            await context.Response.WriteAsJsonAsync(ErrorToReturn);
        }

        private static async Task HandleNotFoundEndPointAsync(HttpContext context)
        {
            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var ErrorToReturn = new ErrorToReturn()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = $"End Point {context.Request.Path} is Not Found"
                };
                await context.Response.WriteAsJsonAsync(ErrorToReturn);
            }
        }
    }
}
