using Microsoft.AspNetCore.Diagnostics;
using Movies.Services.Core.Application.Exceptions;
using Movies.Shared.Dtos;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Movies.Services.Presentation.API.Middlewares
{
    public static class UseCustomExceptionHandler //middlewares dir request geldiğinde buna girer birde response dönecekken girer.
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(c =>
            {
                c.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;
                    //controllere girer CreateActionResult kodunda hatayı fırlatır
                    var response = ResponseDto<NoContentDto>.Fail(exceptionFeature.Error.Message,statusCode);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });
        }
    }
}
