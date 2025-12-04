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
        public int WarehouseId { get; private set; }
        public int StorageSectionId { get; private set; }
        public int StorageTypeId { get; private set; }
        public int InventoryTypeId { get; private set; }

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
            int warehouseId,
            int storageSectionId,
            int storageTypeId,
            int inventoryTypeId)
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
            int warehouseId,
            int storageSectionId,
            int storageTypeId,
            int inventoryTypeId,
            string createdBy)
        {
            var aisle = new AisleDO(name, warehouseId, storageSectionId, storageTypeId, inventoryTypeId);
            aisle.MarkCreated(createdBy);
            return aisle;
        }

        public void Update(
            string name,
            int storageSectionId,
            int storageTypeId,
            int inventoryTypeId,
            string updatedBy)
        {
            Name = name.Trim();
            StorageSectionId = storageSectionId;
            StorageTypeId = storageTypeId;
            InventoryTypeId = inventoryTypeId;

            MarkUpdated(updatedBy);
        }

        public void ChangeWarehouse(int warehouseId, string updatedBy)
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
            int rowLocId,
            string name,
            string updatedBy)
        {
            var rowLoc = _rowLocs.FirstOrDefault(e => e.Id == rowLocId) ??
                throw new InvalidOperationException("Row location does not belong to this aisle.");

            rowLoc.Update(name, updatedBy);

            return rowLoc;
        }

        public void DeleteRowLoc(int rowLocId)
        {
            var rowLoc = _rowLocs.FirstOrDefault(c => c.Id == rowLocId) ??
                throw new InvalidOperationException($"No row location found with id {rowLocId}");

            _rowLocs.Remove(rowLoc);
        }

        public TrayDO CreateTray(
            int rowLocId,
            int capacity,
            string? description,
            string createdBy)
        {
            var rowLoc = _rowLocs.FirstOrDefault(e => e.Id == rowLocId) ??
                throw new InvalidOperationException("Row location does not belong to this aisle.");

            return rowLoc.CreateTray(capacity, description, createdBy);
        }

        public TrayDO UpdateTray(
            int rowLocId,
            int trayId,
            int capacity,
            string? description,
            string updatedBy)
        {
            var rowLoc = _rowLocs.FirstOrDefault(e => e.Id == rowLocId) ??
                throw new InvalidOperationException("Row location does not belong to this aisle.");

            return rowLoc.UpdateTray(trayId, capacity, description, updatedBy);
        }

        public void DeleteTray(int rowLocId, int trayId)
        {
            var rowLoc = _rowLocs.FirstOrDefault(e => e.Id == rowLocId) ??
                throw new InvalidOperationException("Row location does not belong to this aisle.");

            rowLoc.DeleteTray(trayId);
        }

        #endregion
    }
}
