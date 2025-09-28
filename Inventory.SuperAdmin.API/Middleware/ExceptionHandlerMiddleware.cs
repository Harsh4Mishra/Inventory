using FluentValidation;
using Inventory.SuperAdmin.API.Response;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;

namespace Inventory.SuperAdmin.API.Middleware
{
    public class ExceptionHandlerMiddleware : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            context.Response.ContentType = "application/json";

            string exceptionType = exception.GetType().Name;
            object failureData = null;
            int statusCode;
            string message = exception.Message;

            switch (exceptionType)
            {
                case nameof(ValidationException):
                    statusCode = (int)HttpStatusCode.BadRequest;
                    var validationException = exception as ValidationException;
                    List<ValidationResponse> listOfValidationResponses = new List<ValidationResponse>();

                    foreach (var error in validationException.Errors)
                    {
                        listOfValidationResponses.Add(new ValidationResponse { PropertyName = error.PropertyName, ErrorMessage = error.ErrorMessage });
                    }
                    failureData = listOfValidationResponses;
                    break;
                case nameof(ArgumentException):
                    statusCode = (int)HttpStatusCode.BadRequest;
                    failureData = new { Detail = "Invalid argument provided." };
                    break;
                case nameof(ArgumentNullException):
                    statusCode = (int)HttpStatusCode.BadRequest;
                    failureData = new { Detail = "Invalid argument provided." };
                    break;
                case nameof(FileNotFoundException):
                    statusCode = (int)HttpStatusCode.NotFound;
                    failureData = new { Detail = "The requested file was not found." };
                    break;
                case nameof(UnauthorizedAccessException):
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    failureData = new { Detail = "Unauthorized access attempt detected." };
                    break;
                case nameof(TimeoutException):
                    statusCode = (int)HttpStatusCode.RequestTimeout;
                    failureData = new { Detail = "The request timed out." };
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    failureData = new { Detail = message };
                    message = "An unexpected error occurred.";
                    break;
            }

            var response = new FailureAPIResponse<object>(failureData, false, message, statusCode);

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));

            return true;
        }

    }
}
