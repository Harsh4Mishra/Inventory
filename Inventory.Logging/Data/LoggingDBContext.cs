using Inventory.Logging.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Logging.Data
{
    public class LoggingDBContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }

        public LoggingDBContext(DbContextOptions<LoggingDBContext> options)
            : base(options)
        {
        }
    }
}
