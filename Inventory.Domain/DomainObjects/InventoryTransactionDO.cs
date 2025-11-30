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

        public Guid TransactionUUID { get; private set; }
        public DateTime TransactionTime { get; private set; }
        public string TransactionType { get; private set; } = default!;
        public Guid? MaterialBatchId { get; private set; }
        public Guid? ProductId { get; private set; }
        public decimal Quantity { get; private set; }
        public Guid? FromWarehouseId { get; private set; }
        public Guid? ToWarehouseId { get; private set; }
        public Guid? FromAisleId { get; private set; }
        public Guid? ToAisleId { get; private set; }
        public Guid? FromRowId { get; private set; }
        public Guid? ToRowId { get; private set; }
        public Guid? FromTrayId { get; private set; }
        public Guid? ToTrayId { get; private set; }
        public string? ReferenceType { get; private set; }
        public Guid? ReferenceId { get; private set; }
        public Guid CreatedBy { get; private set; }
        public decimal? Cost { get; private set; }
        public string? Notes { get; private set; }

        #endregion

        #region Ctor

        public InventoryTransactionDO() { } // For ORM

        private InventoryTransactionDO(
            string transactionType,
            decimal quantity,
            Guid createdBy,
            Guid? materialBatchId = null,
            Guid? productId = null,
            Guid? fromWarehouseId = null,
            Guid? toWarehouseId = null,
            Guid? fromAisleId = null,
            Guid? toAisleId = null,
            Guid? fromRowId = null,
            Guid? toRowId = null,
            Guid? fromTrayId = null,
            Guid? toTrayId = null,
            string? referenceType = null,
            Guid? referenceId = null,
            decimal? cost = null,
            string? notes = null)
        {
            TransactionUUID = Guid.NewGuid();
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
            Guid createdBy,
            Guid toWarehouseId,
            Guid? materialBatchId = null,
            Guid? productId = null,
            Guid? toAisleId = null,
            Guid? toRowId = null,
            Guid? toTrayId = null,
            string? referenceType = null,
            Guid? referenceId = null,
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
            Guid createdBy,
            Guid fromWarehouseId,
            Guid? materialBatchId = null,
            Guid? productId = null,
            Guid? fromAisleId = null,
            Guid? fromRowId = null,
            Guid? fromTrayId = null,
            string? referenceType = null,
            Guid? referenceId = null,
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
            Guid createdBy,
            Guid fromWarehouseId,
            Guid toWarehouseId,
            Guid? materialBatchId = null,
            Guid? productId = null,
            Guid? fromAisleId = null,
            Guid? toAisleId = null,
            Guid? fromRowId = null,
            Guid? toRowId = null,
            Guid? fromTrayId = null,
            Guid? toTrayId = null,
            string? referenceType = null,
            Guid? referenceId = null,
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
            Guid createdBy,
            Guid? warehouseId,
            Guid? materialBatchId = null,
            Guid? productId = null,
            Guid? aisleId = null,
            Guid? rowId = null,
            Guid? trayId = null,
            string? referenceType = null,
            Guid? referenceId = null,
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
