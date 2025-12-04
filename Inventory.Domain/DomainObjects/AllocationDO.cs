using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class AllocationDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public int MaterialBatchId { get; private set; }
        public decimal Quantity { get; private set; }
        public string Status { get; private set; } = default!;

        #endregion

        #region Ctor

        public AllocationDO() { } // For ORM

        private AllocationDO(
            int orderId,
            int productId,
            int materialBatchId,
            decimal quantity,
            string status)
        {
            OrderId = orderId;
            ProductId = productId;
            MaterialBatchId = materialBatchId;
            Quantity = quantity;
            Status = status?.Trim();
        }

        #endregion

        #region Methods

        public static AllocationDO Create(
            int orderId,
            int productId,
            int materialBatchId,
            decimal quantity,
            string createdBy)
        {
            var allocation = new AllocationDO(
                orderId,
                productId,
                materialBatchId,
                quantity,
                "allocated");

            allocation.MarkCreated(createdBy);
            return allocation;
        }

        public void MarkAsPicked(string updatedBy)
        {
            if (Status != "allocated")
                throw new InvalidOperationException($"Cannot pick allocation with status: {Status}");

            Status = "picked";
            MarkUpdated(updatedBy);
        }

        public void MarkAsShipped(string updatedBy)
        {
            if (Status != "picked")
                throw new InvalidOperationException($"Cannot ship allocation with status: {Status}");

            Status = "shipped";
            MarkUpdated(updatedBy);
        }

        public void Release(string updatedBy)
        {
            if (Status != "allocated" && Status != "picked")
                throw new InvalidOperationException($"Cannot release allocation with status: {Status}");

            Status = "released";
            MarkUpdated(updatedBy);
        }

        public void Cancel(string updatedBy)
        {
            if (Status == "shipped")
                throw new InvalidOperationException("Cannot cancel shipped allocation");

            Status = "cancelled";
            MarkUpdated(updatedBy);
        }

        public void UpdateQuantity(decimal quantity, string updatedBy)
        {
            if (Status != "allocated")
                throw new InvalidOperationException($"Cannot update quantity for allocation with status: {Status}");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0");

            Quantity = quantity;
            MarkUpdated(updatedBy);
        }

        #endregion
    }
}
