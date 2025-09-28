namespace Inventory.SuperAdmin.API.Response.Common
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; } = false;
        public int StatusCode { get; set; } = 0;
        public string Message { get; set; } = string.Empty;
    }
}
