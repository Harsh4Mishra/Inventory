namespace Inventory.Application.Contracts
{
    public interface IOTPService
    {
        public Task<string> SendOtpRequestAsync(string MobileNumber);
        public Task<string> VerifyOtpRequestAsync(string MobileNumber, string OTP);
    }
}
