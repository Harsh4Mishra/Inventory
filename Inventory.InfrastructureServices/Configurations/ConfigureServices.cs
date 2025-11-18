using Inventory.Application.Contracts;
using Inventory.InfrastructureServices.Services.Auth;
using Inventory.InfrastructureServices.Services.Cryptography.AES;
using Inventory.InfrastructureServices.Services.Cryptography.UTF;
using Inventory.InfrastructureServices.Services.Mail;
using Inventory.InfrastructureServices.Services.OTP;
using Inventory.InfrastructureServices.Services.SMS;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.InfrastructureServices.Configurations
{
    public static class ConfigureServices
    {
        #region Methods

        public static IServiceCollection InjectInfrastructureServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUTFService, UTFService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IAesService, AesService>();
            services.AddScoped<IOTPService, OTPService>();
            services.AddScoped<ISMSService, SMSService>();

            return services;
        }

        #endregion
    }
}
