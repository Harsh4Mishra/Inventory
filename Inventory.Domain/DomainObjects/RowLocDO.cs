using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class RowLocDO : AuditableDO
    {
        #region Fields

        private List<TrayDO> _trays = new();

        #endregion

        #region Properties

        public int AisleId { get; private set; } = default;
        public string Name { get; private set; } = default!;

        #region Navigation Properties

        public IReadOnlyCollection<TrayDO> Trays => _trays.AsReadOnly();

        #endregion

        #endregion

        #region Ctor

        private RowLocDO() { } // For ORM

        private RowLocDO(
            int aisleId,
            string name)
        {
            AisleId = aisleId;
            Name = name.Trim();
        }

        #endregion

        #region Methods

        internal static RowLocDO Create(
            int aisleId,
            string name,
            string createdBy)
        {
            var rowLoc = new RowLocDO(aisleId, name);
            rowLoc.MarkCreated(createdBy);
            return rowLoc;
        }

        internal void Update(
            string name,
            string updatedBy)
        {
            Name = name.Trim();
            MarkUpdated(updatedBy);
        }

        internal TrayDO CreateTray(
            int capacity,
            string? description,
            string createdBy)
        {
            var tray = TrayDO.Create(Id, capacity, description, createdBy);
            _trays.Add(tray);
            return tray;
        }

        internal TrayDO UpdateTray(
            int trayId,
            int capacity,
            string? description,
            string updatedBy)
        {
            var tray = _trays.FirstOrDefault(e => e.Id == trayId) ??
                throw new InvalidOperationException("Tray does not belong to this row location.");

            tray.Update(capacity, description, updatedBy);
            return tray;
        }

        internal void DeleteTray(int trayId)
        {
            var tray = _trays.FirstOrDefault(c => c.Id == trayId) ??
                throw new InvalidOperationException($"No tray found with id {trayId}");

            _trays.Remove(tray);
        }

        #endregion
    }
}
