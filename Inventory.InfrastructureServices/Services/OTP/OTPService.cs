using Inventory.Application.Contracts;
using Microsoft.Extensions.Configuration;

namespace Inventory.InfrastructureServices.Services.OTP
{
    public class OTPService : IOTPService
    {
        private readonly IConfiguration _configuration;

        public OTPService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> SendOtpRequestAsync(string MobileNumber)
        {
            using (var client = new HttpClient())
            {
                string newMobileNumber = "91" + MobileNumber;

                int otpLength = int.Parse(_configuration["SMSConfiguration:OTPLength"]);
                string? authKey = _configuration["SMSConfiguration:AuthKey"];
                string? templateID = _configuration["SMSConfiguration:OTPTemplateID"];

                var url = $"https://control.msg91.com/api/v5/otp?otp_length={otpLength}&template_id={templateID}&mobile={newMobileNumber}&authkey={authKey}";

                var response = await client.PostAsync(url, null);
                // Handle the response
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }

        }
        public async Task<string> VerifyOtpRequestAsync(string MobileNumber, string OTP)
        {
            using (var client = new HttpClient())
            {
                string newMobileNumber = "91" + MobileNumber;

                int otpLength = int.Parse(_configuration["SMSConfiguration:OTPLength"]);
                string? authKey = _configuration["SMSConfiguration:AuthKey"];
                string? templateID = _configuration["SMSConfiguration:TemplateID"];

                // Construct the URL with query parameters
                var url = $"https://control.msg91.com/api/v5/otp/verify?otp={OTP}&mobile={newMobileNumber}";

                // Set the authorization header
                client.DefaultRequestHeaders.Add("authkey", authKey);

                // Send the GET request
                var response = await client.GetAsync(url);
                // Handle the response
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }

        }
    }
}
