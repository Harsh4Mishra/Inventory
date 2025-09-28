namespace Inventory.Application.Contracts
{
    public interface ISMSService
    {
        #region Signatures

        public Task Send(string phoneNo, string message, CancellationToken cancellationToken);
        public Task SendOTP(string phoneNo, string otp, int otpExpiryInMinutes, CancellationToken cancellationToken);
        public Task SendOTP(string phoneNo, int otpLength, int otpExpiryInMinutes, CancellationToken cancellationToken);
        public Task VerifyOTP(string phoneNo, string otp, CancellationToken cancellationToken);

        #endregion
    }
}
