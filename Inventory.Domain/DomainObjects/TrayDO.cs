using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class TrayDO : AuditableDO
    {
        #region Properties

        public int RowId { get; private set; } = default;
        public int Capacity { get; private set; }
        public string? Description { get; private set; }

        #endregion

        #region Ctor

        private TrayDO() { } // For ORM

        private TrayDO(
            int rowId,
            int capacity,
            string? description)
        {
            RowId = rowId;
            Capacity = capacity;
            Description = description?.Trim();
        }

        #endregion

        #region Methods

        internal static TrayDO Create(
            int rowId,
            int capacity,
            string? description,
            string createdBy)
        {
            var tray = new TrayDO(rowId, capacity, description);
            tray.MarkCreated(createdBy);
            return tray;
        }

        internal void Update(
            int capacity,
            string? description,
            string updatedBy)
        {
            Capacity = capacity;
            Description = description?.Trim();
            MarkUpdated(updatedBy);
        }

        internal void ChangeRow(int rowId, string updatedBy)
        {
            RowId = rowId;
            MarkUpdated(updatedBy);
        }

        #endregion
    }
}
