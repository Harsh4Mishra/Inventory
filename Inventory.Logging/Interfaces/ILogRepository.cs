
using Inventory.Logging.Models;

namespace Inventory.Logging.Interfaces
{
    public interface ILogRepository
    {
        Task SaveTicketAsync(Ticket ticket);
    }
}
