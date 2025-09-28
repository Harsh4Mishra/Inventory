
namespace Inventory.Logging.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RequestPath { get; set; }
    }
}
