
using Serilog;

namespace Inventory.Logging.Configure
{
    public static class LoggerConfigurator
    {
        public static void ConfigureLogger()
        {
            //var path = string.IsNullOrWhiteSpace(logFilePath) ? "Logs/default-log-.txt" : logFilePath;

            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Information()
            //    .Enrich.FromLogContext()
            //    .WriteTo.File(
            //        path: path,
            //        rollingInterval: RollingInterval.Day,
            //        restrictedToMinimumLevel: LogEventLevel.Information
            //    )
            //    .CreateLogger();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .CreateLogger();
        }
    }
}
