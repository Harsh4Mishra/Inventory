using Inventory.Logging.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Inventory.Logging.Repository
{
    public class FileLogWriter : ILogWriter
    {
        private readonly string _logDirectory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileLogWriter(string logDirectory, IHttpContextAccessor httpContextAccessor)
        {
            _logDirectory = logDirectory ?? throw new ArgumentNullException(nameof(logDirectory));
            _httpContextAccessor = httpContextAccessor;
            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);

            }
        }

        public void WriteLog(string logType, string message, string? details = null)
        {
            var ticketId = _httpContextAccessor.HttpContext?.Items["TicketId"] as Guid? ?? Guid.NewGuid();
            var filePath = Path.Combine(_logDirectory, $"{ticketId}.txt");
            var logMessage = $"{ticketId} : {DateTime.Now:yyyy-MM-dd HH:mm:ss} : {logType} : {message} : {details ?? "N/A"}{Environment.NewLine}";

            File.AppendAllText(filePath, logMessage);
        }
    }
}
