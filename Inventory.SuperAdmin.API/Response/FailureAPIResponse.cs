using Inventory.SuperAdmin.API.Response.Common;
using Microsoft.AspNetCore.Http;

namespace Inventory.SuperAdmin.API.Response
{
    public class FailureAPIResponse<TError> : ApiResponse
    {
        public TError Error { get; set; } = default(TError);

        public FailureAPIResponse(TError data, bool isSuccess, string message, int statusCode)
        {
            Error = data;
            IsSuccess = isSuccess;
            Message = message;
            StatusCode = statusCode;
        }
    }
}
