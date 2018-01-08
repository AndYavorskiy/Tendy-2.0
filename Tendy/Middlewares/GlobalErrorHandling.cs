using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading.Tasks;
using Tendy.Common.Exceptions;

namespace Tendy.Middlewares
{
    public sealed class GlobalErrorHandling
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (CustomException ex)
            {
                await SendErroResponse(context, ex.StatusCode.Value, ex.Message, ex.ErrorCode);
            }
            catch (Exception ex)
            {
                await SendErroResponse(context, StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private static async Task SendErroResponse(HttpContext context, int statusCode, string message = null, string errorCode = null)
        {
            var response = new
            {
                StatusCode = statusCode,
                ErrorCode = errorCode,
                Message = message
            };

            var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(json);
        }
    }
}
