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

        public int MaterialBatchId { get; private set; }
        public int WarehouseId { get; private set; }
        public int AisleId { get; private set; }
        public int RowId { get; private set; }
        public int TrayId { get; private set; }
        public decimal Quantity { get; private set; }
        public string Name { get; private set; } = default!;
        public string? Specification { get; private set; }

        #endregion

        #region Ctor

        public WarehouseItemDO() { } // For ORM

        public WarehouseItemDO(
            int materialBatchId,
            int warehouseId,
            int aisleId,
            int rowId,
            int trayId,
            decimal quantity,
            string name,
            string? specification)
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
            int materialBatchId,
            int warehouseId,
            int aisleId,
            int rowId,
            int trayId,
            decimal quantity,
            string name,
            string? specification,
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
            int warehouseId,
            int aisleId,
            int rowId,
            int trayId,
            string updatedBy)
        {
            WarehouseId = warehouseId;
            AisleId = aisleId;
            RowId = rowId;
            TrayId = trayId;
            MarkUpdated(updatedBy);
        }

        public void UpdateSpecification(
            string? specification,
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
