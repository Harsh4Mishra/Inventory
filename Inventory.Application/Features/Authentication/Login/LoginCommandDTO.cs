namespace Inventory.Application.Features.Authentication.Login
{
    public class LoginCommandDTO
    {
        #region properties

        public string Name { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public int EmployeeID { get; set; } = default;
        public string JWTToken { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = default;

        #endregion
    }
}
