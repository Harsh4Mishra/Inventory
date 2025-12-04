using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class BomItemDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public int BomId { get; private set; }
        public int MaterialBatchId { get; private set; }
        public int WarehouseItemId { get; private set; }
        public decimal Quantity { get; private set; }

        #endregion

        #region Ctor

        public BomItemDO() { } // For ORM

        public BomItemDO(
            int bomId,
            int materialBatchId,
            int warehouseItemId,
            decimal quantity)
        {
            BomId = bomId;
            MaterialBatchId = materialBatchId;
            WarehouseItemId = warehouseItemId;
            Quantity = quantity;
        }

        #endregion

        #region Methods

        public static BomItemDO Create(
            int bomId,
            int materialBatchId,
            int warehouseItemId,
            decimal quantity,
            string createdBy)
        {
            var bomItem = new BomItemDO(bomId, materialBatchId, warehouseItemId, quantity);

            bomItem.MarkCreated(createdBy);

            return bomItem;
        }

        public void UpdateQuantity(
            decimal quantity,
            string updatedBy)
        {
            Quantity = quantity;
            MarkUpdated(updatedBy);
        }

        public void UpdateMaterialBatch(
            int materialBatchId,
            string updatedBy)
        {
            MaterialBatchId = materialBatchId;
            MarkUpdated(updatedBy);
        }

        public void UpdateWarehouseItem(
            int warehouseItemId,
            string updatedBy)
        {
            WarehouseItemId = warehouseItemId;
            MarkUpdated(updatedBy);
        }

        #endregion
    }
}
