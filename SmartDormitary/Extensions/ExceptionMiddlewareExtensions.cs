﻿using Microsoft.AspNetCore.Builder;
using SmartDormitary.Middlewares;

namespace SmartDormitary.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}