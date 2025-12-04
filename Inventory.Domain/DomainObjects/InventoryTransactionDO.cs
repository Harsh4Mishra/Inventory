using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class InventoryTransactionDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public string TransactionUUID { get; private set; }
        public DateTime TransactionTime { get; private set; }
        public string TransactionType { get; private set; } = default!;
        public int? MaterialBatchId { get; private set; }
        public int? ProductId { get; private set; }
        public decimal Quantity { get; private set; }
        public int? FromWarehouseId { get; private set; }
        public int? ToWarehouseId { get; private set; }
        public int? FromAisleId { get; private set; }
        public int? ToAisleId { get; private set; }
        public int? FromRowId { get; private set; }
        public int? ToRowId { get; private set; }
        public int? FromTrayId { get; private set; }
        public int? ToTrayId { get; private set; }
        public string? ReferenceType { get; private set; }
        public int? ReferenceId { get; private set; }
        public int CreatedBy { get; private set; }
        public decimal? Cost { get; private set; }
        public string? Notes { get; private set; }

        #endregion

        #region Ctor

        public InventoryTransactionDO() { } // For ORM

        private InventoryTransactionDO(
            string transactionType,
            decimal quantity,
            int createdBy,
            int? materialBatchId = null,
            int? productId = null,
            int? fromWarehouseId = null,
            int? toWarehouseId = null,
            int? fromAisleId = null,
            int? toAisleId = null,
            int? fromRowId = null,
            int? toRowId = null,
            int? fromTrayId = null,
            int? toTrayId = null,
            string? referenceType = null,
            int? referenceId = null,
            decimal? cost = null,
            string? notes = null)
        {
            TransactionUUID = DateTime.Now.ToString("ddMMyyHHmmss");
            TransactionTime = DateTime.UtcNow;
            TransactionType = transactionType.Trim();
            Quantity = quantity;
            CreatedBy = createdBy;
            MaterialBatchId = materialBatchId;
            ProductId = productId;
            FromWarehouseId = fromWarehouseId;
            ToWarehouseId = toWarehouseId;
            FromAisleId = fromAisleId;
            ToAisleId = toAisleId;
            FromRowId = fromRowId;
            ToRowId = toRowId;
            FromTrayId = fromTrayId;
            ToTrayId = toTrayId;
            ReferenceType = referenceType?.Trim();
            ReferenceId = referenceId;
            Cost = cost;
            Notes = notes?.Trim();
        }

        #endregion

        #region Methods

        public static InventoryTransactionDO CreateReceive(
            decimal quantity,
            int createdBy,
            int toWarehouseId,
            int? materialBatchId = null,
            int? productId = null,
            int? toAisleId = null,
            int? toRowId = null,
            int? toTrayId = null,
            string? referenceType = null,
            int? referenceId = null,
            decimal? cost = null,
            string? notes = null)
        {
            var transaction = new InventoryTransactionDO(
                "receive",
                quantity,
                createdBy,
                materialBatchId: materialBatchId,
                productId: productId,
                toWarehouseId: toWarehouseId,
                toAisleId: toAisleId,
                toRowId: toRowId,
                toTrayId: toTrayId,
                referenceType: referenceType,
                referenceId: referenceId,
                cost: cost,
                notes: notes);

            transaction.MarkCreated(createdBy.ToString());
            return transaction;
        }

        public static InventoryTransactionDO CreateIssue(
            decimal quantity,
            int createdBy,
            int fromWarehouseId,
            int? materialBatchId = null,
            int? productId = null,
            int? fromAisleId = null,
            int? fromRowId = null,
            int? fromTrayId = null,
            string? referenceType = null,
            int? referenceId = null,
            decimal? cost = null,
            string? notes = null)
        {
            var transaction = new InventoryTransactionDO(
                "issue",
                quantity,
                createdBy,
                materialBatchId: materialBatchId,
                productId: productId,
                fromWarehouseId: fromWarehouseId,
                fromAisleId: fromAisleId,
                fromRowId: fromRowId,
                fromTrayId: fromTrayId,
                referenceType: referenceType,
                referenceId: referenceId,
                cost: cost,
                notes: notes);

            transaction.MarkCreated(createdBy.ToString());
            return transaction;
        }

        public static InventoryTransactionDO CreateTransfer(
            decimal quantity,
            int createdBy,
            int fromWarehouseId,
            int toWarehouseId,
            int? materialBatchId = null,
            int? productId = null,
            int? fromAisleId = null,
            int? toAisleId = null,
            int? fromRowId = null,
            int? toRowId = null,
            int? fromTrayId = null,
            int? toTrayId = null,
            string? referenceType = null,
            int? referenceId = null,
            decimal? cost = null,
            string? notes = null)
        {
            var transaction = new InventoryTransactionDO(
                "transfer",
                quantity,
                createdBy,
                materialBatchId: materialBatchId,
                productId: productId,
                fromWarehouseId: fromWarehouseId,
                toWarehouseId: toWarehouseId,
                fromAisleId: fromAisleId,
                toAisleId: toAisleId,
                fromRowId: fromRowId,
                toRowId: toRowId,
                fromTrayId: fromTrayId,
                toTrayId: toTrayId,
                referenceType: referenceType,
                referenceId: referenceId,
                cost: cost,
                notes: notes);

            transaction.MarkCreated(createdBy.ToString());
            return transaction;
        }

        public static InventoryTransactionDO CreateAdjustment(
            decimal quantity,
            int createdBy,
            int? warehouseId,
            int? materialBatchId = null,
            int? productId = null,
            int? aisleId = null,
            int? rowId = null,
            int? trayId = null,
            string? referenceType = null,
            int? referenceId = null,
            decimal? cost = null,
            string? notes = null)
        {
            var transaction = new InventoryTransactionDO(
                "adjust",
                quantity,
                createdBy,
                materialBatchId: materialBatchId,
                productId: productId,
                fromWarehouseId: warehouseId,
                toWarehouseId: warehouseId,
                fromAisleId: aisleId,
                toAisleId: aisleId,
                fromRowId: rowId,
                toRowId: rowId,
                fromTrayId: trayId,
                toTrayId: trayId,
                referenceType: referenceType,
                referenceId: referenceId,
                cost: cost,
                notes: notes);

            transaction.MarkCreated(createdBy.ToString());
            return transaction;
        }

        public void UpdateNotes(string notes, string updatedBy)
        {
            Notes = notes?.Trim();
            MarkUpdated(updatedBy);
        }

        public void UpdateCost(decimal cost, string updatedBy)
        {
            Cost = cost;
            MarkUpdated(updatedBy);
        }

        #endregion
    }
}
