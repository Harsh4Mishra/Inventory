using Inventory.SuperAdmin.API.Response.Common;
using Microsoft.AspNetCore.Http;

namespace Inventory.SuperAdmin.API.Response
{
    public class SuccessAPIResponse<T> : ApiResponse
    {
        public T Data { get; set; } = default(T);

        public SuccessAPIResponse(T data, bool isSuccess, string message, int statusCode)
        {
            Data = data;
            IsSuccess = isSuccess;
            Message = message;
            StatusCode = statusCode;
        }
    }
}
