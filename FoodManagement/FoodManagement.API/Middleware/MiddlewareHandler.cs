using FoodManagement.Controllers;
using FoodManagement.Services;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
namespace FoodManagement.API.Middleware
{
    public class MiddlewareHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private MiddlewareService _middlewareService;
     

     
        public MiddlewareHandler(RequestDelegate next, ILogger<MiddlewareHandler> logger, MiddlewareService middlewareService)
        {
            _next = next;
            _logger = logger;
            _middlewareService = middlewareService;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                /*if (context.Request.Headers.ContainsKey("UserId"))
                {
                    string userId = context.Request.Headers["UserId"];
                    Task<bool> result = _middlewareService.IsUserExist(userId);
                    if (result.Result)
                    {
                        await _next(context);
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.Response.WriteAsync("User ID  didn't valid");
                        return;
                    }
                }*/
          
                    await _next(context);
                
                

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var problemStatement = new
                {

                    Type = "Server Error",
                    ErrorMessage = ex.Message,
                    status = (int)HttpStatusCode.InternalServerError,
                    Title = "Internal Server Error"
                };
                string problem = JsonSerializer.Serialize(problemStatement);
                await context.Response.WriteAsync(problem);
            }
        }

    }
}
