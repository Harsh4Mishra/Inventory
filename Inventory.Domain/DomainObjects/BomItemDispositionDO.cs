using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class BomItemDispositionDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public int BomItemId { get; private set; }
        public string Disposition { get; private set; } = default!;
        public string? Notes { get; private set; }
        public DateTime ProcessedOn { get; private set; }

        #endregion

        #region Ctor

        public BomItemDispositionDO() { } // For ORM

        public BomItemDispositionDO(
            int bomItemId,
            string disposition,
            string? notes)
        {
            BomItemId = bomItemId;
            Disposition = disposition.Trim();
            Notes = notes?.Trim();
            ProcessedOn = DateTime.UtcNow;
        }

        #endregion

        #region Methods

        public static BomItemDispositionDO Create(
            int bomItemId,
            string disposition,
            string? notes,
            string createdBy)
        {
            var dispositionItem = new BomItemDispositionDO(bomItemId, disposition, notes);
            dispositionItem.MarkCreated(createdBy);
            return dispositionItem;
        }

        public void Update(
            string disposition,
            string? notes,
            string updatedBy)
        {
            Disposition = disposition.Trim();
            Notes = notes?.Trim();

            MarkUpdated(updatedBy);
        }

        public void UpdateProcessedDate(DateTime processedOn, string updatedBy)
        {
            ProcessedOn = processedOn;
            MarkUpdated(updatedBy);
        }

        #endregion
    }
}
