using Inventory.Logging.Data;
using Inventory.Logging.Interfaces;
using Inventory.Logging.Models;

namespace Inventory.Logging.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly LoggingDBContext _context;

        public LogRepository(LoggingDBContext context)
        {
            _context = context;
        }

        public async Task SaveTicketAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
