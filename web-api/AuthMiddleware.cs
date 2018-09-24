using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_api
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ApiKey _apiKey;

        public AuthMiddleware(RequestDelegate next, ApiKey apiKey)
        {
            _next = next;
            _apiKey = apiKey;
        }

        public async Task Invoke(HttpContext context)
        {
            var headers = context.Request.Headers;

            if (!headers.ContainsKey("x-api-key")) 
            {
                context.Response.StatusCode = 400;
                throw new System.Exception();
            }
            else 
            {
                if (headers["x-api-key"] != _apiKey) 
                {
                    context.Response.StatusCode = 403;
                    throw new System.Exception();
                }
            }

            await _next(context);

        }
    }
}
