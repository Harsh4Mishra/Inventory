using Inventory.Logging.Data;
using Inventory.Logging.Filters;
using Inventory.Logging.Interfaces;
using Inventory.Logging.Models;
using Inventory.Logging.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Logging.Configure
{
    public static class LoggingServiceCollectionExtensions
    {
        public static IServiceCollection AddLoggingLibrary(
            this IServiceCollection services,
            Action<LoggingOptions> configureOptions)
        {
            var options = new LoggingOptions();
            configureOptions?.Invoke(options);

            services.AddSingleton(options);


            // Configure EF Core for saving ticket to DB
            if (!string.IsNullOrWhiteSpace(options.DatabaseConnectionString))
            {
                services.AddDbContext<LoggingDBContext>(db =>
                    db.UseSqlServer(options.DatabaseConnectionString));
                services.AddScoped<ILogRepository, LogRepository>();
            }

            //services.AddHttpContextAccessor();
            // Configure the FileLogWriter with the directory path
            if (!string.IsNullOrWhiteSpace(options.FileLogDirectory))
            {
                //services.AddSingleton<ILogWriter>(
                //    new FileLogWriter(options.FileLogDirectory));
                services.AddSingleton<ILogWriter>(sp =>
                {
                    var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
                    return new FileLogWriter(options.FileLogDirectory, httpContextAccessor);
                });
            }

            // Optional: register filters/services
            services.AddScoped<TicketLoggingFilter>();

            // Configure Serilog globally (optional)
            LoggerConfigurator.ConfigureLogger();

            return services;
        }
    }
}
