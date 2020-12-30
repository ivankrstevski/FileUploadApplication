using FileUploadApp.BusinessModel;
using FileUploadApp.Configurations.CustomExceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FileUploadApp
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var message = "Internal Server Error.";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var exception = contextFeature.Error;

                    if (exception is FileAlreadyExistsException)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                        message = exception.Message;
                    }

                    if (contextFeature != null)
                    {
                        logger.LogError($"An error has occurred: { exception.Message }");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = message
                        }.ToString());
                    }
                });
            });
        }
    }
}
