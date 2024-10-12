using Aplication.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aplication.Common.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;

        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment environment)
        {
            _next = next;
            _environment = environment;
        }

        public async Task InvoKeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
               await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleGeneralExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, NotFoundException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)ex.StatusCode;

            // Include stack trace only in development mode
            var response = new ErrorException()
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
                Details = _environment.IsDevelopment() ? ex.StackTrace : null 
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private Task HandleGeneralExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            // Set a default status code
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Include stack trace only in development mode
            var response = new ErrorException()
            {
                StatusCode = context.Response.StatusCode,
                Message = "An unexpected error occurred. Please try again later.",
                Details = _environment.IsDevelopment() ? ex.StackTrace : null
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
