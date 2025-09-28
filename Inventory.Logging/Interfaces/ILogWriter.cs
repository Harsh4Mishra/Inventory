
namespace Inventory.Logging.Interfaces
{
    public interface ILogWriter
    {
        void WriteLog(string logType, string logMessage, string? logDetails = null);
    }
}
