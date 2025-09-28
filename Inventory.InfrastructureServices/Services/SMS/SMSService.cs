using Inventory.Application.Contracts;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Inventory.InfrastructureServices.Services.SMS
{
    public class SMSService : ISMSService
    {
        private readonly IConfiguration _configuration;

        public SMSService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task Send(string phoneNo, string message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SendFlowRequestAsync(string mobileNo, string otp)
        {
            using (var client = new HttpClient())
            {
                string countryCode = _configuration["SMSConfiguration:CountryCode"].ToString();
                // Construct mobile number with country code
                string newMobileNumber = countryCode + mobileNo;

                // Fetch configuration values
                string? apiUrl = _configuration["SMSConfiguration:SMSAPIURL"];
                string? authKey = _configuration["SMSConfiguration:AuthKey"];
                string? templateId = _configuration["SMSConfiguration:SMSTemplateID"];

                // Construct the JSON payload with only OTP
                bool shortUrl = true; // Enable short URLs
                bool realTimeResponse = true; // Enable real-time response
                var jsonPayload = $@"
                                {{
                                    ""template_id"": ""{templateId}"",
                                    ""short_url"": ""{(shortUrl ? "1" : "0")}"",
                                    ""realTimeResponse"": ""{(realTimeResponse ? "1" : "0")}"",
                                    ""recipients"": [
                                        {{
                                            ""mobiles"": ""{newMobileNumber}"",
                                            ""OTP"": ""{otp}""
                                        }}
                                    ]
                                }}";

                // Set up the HTTP request
                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
                {
                    Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json")
                };

                // Add the authorization header
                request.Headers.Add("authkey", authKey);

                // Send the request and handle the response
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {
                    return $"Error: {response.StatusCode}, Message: {await response.Content.ReadAsStringAsync()}";
                }
            }
        }

        public Task SendOTP(string phoneNo, string otp, int otpExpiryInMinutes, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SendOTP(string phoneNo, int otpLength, int otpExpiryInMinutes, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task VerifyOTP(string phoneNo, string otp, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
