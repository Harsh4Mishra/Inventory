using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class AisleDO : AuditableDO, IAggregateRoot
    {
        #region Fields

        private List<RowLocDO> _rowLocs = new();

        #endregion

        #region Properties

        public string Name { get; private set; } = default!;
        public Guid WarehouseId { get; private set; }
        public Guid StorageSectionId { get; private set; }
        public Guid StorageTypeId { get; private set; }
        public Guid InventoryTypeId { get; private set; }

        // Navigation properties
        public WarehouseDO? Warehouse { get; private set; }
        public StorageSectionDO? StorageSection { get; private set; }

        #region Navigation Properties

        public IReadOnlyCollection<RowLocDO> RowLocs => _rowLocs.AsReadOnly();

        #endregion

        #endregion

        #region Ctor

        private AisleDO() { } // For ORM

        private AisleDO(
            string name,
            Guid warehouseId,
            Guid storageSectionId,
            Guid storageTypeId,
            Guid inventoryTypeId)
        {
            Name = name.Trim();
            WarehouseId = warehouseId;
            StorageSectionId = storageSectionId;
            StorageTypeId = storageTypeId;
            InventoryTypeId = inventoryTypeId;
        }

        #endregion

        #region Methods

        public static AisleDO Create(
            string name,
            Guid warehouseId,
            Guid storageSectionId,
            Guid storageTypeId,
            Guid inventoryTypeId,
            string createdBy)
        {
            var aisle = new AisleDO(name, warehouseId, storageSectionId, storageTypeId, inventoryTypeId);
            aisle.MarkCreated(createdBy);
            return aisle;
        }

        public void Update(
            string name,
            Guid storageSectionId,
            Guid storageTypeId,
            Guid inventoryTypeId,
            string updatedBy)
        {
            Name = name.Trim();
            StorageSectionId = storageSectionId;
            StorageTypeId = storageTypeId;
            InventoryTypeId = inventoryTypeId;

            MarkUpdated(updatedBy);
        }

        public void ChangeWarehouse(Guid warehouseId, string updatedBy)
        {
            WarehouseId = warehouseId;
            MarkUpdated(updatedBy);
        }

        public RowLocDO CreateRowLoc(
            string name,
            string createdBy)
        {
            if (_rowLocs.Where(e => e.Name == name).Any())
            {
                throw new InvalidOperationException("Already a row location with same name belongs to this aisle");
            }

            var rowLoc = RowLocDO.Create(Id, name, createdBy);

            _rowLocs.Add(rowLoc);

            return rowLoc;
        }

        public RowLocDO UpdateRowLoc(
            Guid rowLocId,
            string name,
            string updatedBy)
        {
            var rowLoc = _rowLocs.FirstOrDefault(e => e.Id == rowLocId) ??
                throw new InvalidOperationException("Row location does not belong to this aisle.");

            rowLoc.Update(name, updatedBy);

            return rowLoc;
        }

        public void DeleteRowLoc(Guid rowLocId)
        {
            var rowLoc = _rowLocs.FirstOrDefault(c => c.Id == rowLocId) ??
                throw new InvalidOperationException($"No row location found with id {rowLocId}");

            _rowLocs.Remove(rowLoc);
        }

        public TrayDO CreateTray(
            Guid rowLocId,
            int capacity,
            string? description,
            string createdBy)
        {
            var rowLoc = _rowLocs.FirstOrDefault(e => e.Id == rowLocId) ??
                throw new InvalidOperationException("Row location does not belong to this aisle.");

            return rowLoc.CreateTray(capacity, description, createdBy);
        }

        public TrayDO UpdateTray(
            Guid rowLocId,
            Guid trayId,
            int capacity,
            string? description,
            string updatedBy)
        {
            var rowLoc = _rowLocs.FirstOrDefault(e => e.Id == rowLocId) ??
                throw new InvalidOperationException("Row location does not belong to this aisle.");

            return rowLoc.UpdateTray(trayId, capacity, description, updatedBy);
        }

        public void DeleteTray(Guid rowLocId, Guid trayId)
        {
            var rowLoc = _rowLocs.FirstOrDefault(e => e.Id == rowLocId) ??
                throw new InvalidOperationException("Row location does not belong to this aisle.");

            rowLoc.DeleteTray(trayId);
        }

        #endregion
    }
}
