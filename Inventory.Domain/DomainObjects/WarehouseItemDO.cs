using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class WarehouseItemDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public Guid MaterialBatchId { get; private set; }
        public Guid WarehouseId { get; private set; }
        public Guid AisleId { get; private set; }
        public Guid RowId { get; private set; }
        public Guid TrayId { get; private set; }
        public decimal Quantity { get; private set; }
        public string Name { get; private set; } = default!;
        public JsonDocument? Specification { get; private set; }

        #endregion

        #region Ctor

        public WarehouseItemDO() { } // For ORM

        public WarehouseItemDO(
            Guid materialBatchId,
            Guid warehouseId,
            Guid aisleId,
            Guid rowId,
            Guid trayId,
            decimal quantity,
            string name,
            JsonDocument? specification)
        {
            MaterialBatchId = materialBatchId;
            WarehouseId = warehouseId;
            AisleId = aisleId;
            RowId = rowId;
            TrayId = trayId;
            Quantity = quantity;
            Name = name.Trim();
            Specification = specification;
        }

        #endregion

        #region Methods

        public static WarehouseItemDO Create(
            Guid materialBatchId,
            Guid warehouseId,
            Guid aisleId,
            Guid rowId,
            Guid trayId,
            decimal quantity,
            string name,
            JsonDocument? specification,
            string createdBy)
        {
            var warehouseItem = new WarehouseItemDO(
                materialBatchId,
                warehouseId,
                aisleId,
                rowId,
                trayId,
                quantity,
                name,
                specification);

            warehouseItem.MarkCreated(createdBy);

            return warehouseItem;
        }

        public void UpdateQuantity(
            decimal quantity,
            string updatedBy)
        {
            Quantity = quantity;
            MarkUpdated(updatedBy);
        }

        public void UpdateLocation(
            Guid warehouseId,
            Guid aisleId,
            Guid rowId,
            Guid trayId,
            string updatedBy)
        {
            WarehouseId = warehouseId;
            AisleId = aisleId;
            RowId = rowId;
            TrayId = trayId;
            MarkUpdated(updatedBy);
        }

        public void UpdateSpecification(
            JsonDocument? specification,
            string updatedBy)
        {
            Specification = specification;
            MarkUpdated(updatedBy);
        }

        public void UpdateName(
            string name,
            string updatedBy)
        {
            Name = name.Trim();
            MarkUpdated(updatedBy);
        }

        public void AddQuantity(
            decimal quantityToAdd,
            string updatedBy)
        {
            Quantity += quantityToAdd;
            MarkUpdated(updatedBy);
        }

        public void RemoveQuantity(
            decimal quantityToRemove,
            string updatedBy)
        {
            if (quantityToRemove > Quantity)
                throw new InvalidOperationException("Cannot remove more quantity than available");

            Quantity -= quantityToRemove;
            MarkUpdated(updatedBy);
        }

        #endregion
    }
}
