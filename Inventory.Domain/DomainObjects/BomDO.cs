using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class BomDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public string Name { get; private set; } = default!;
        public bool IsApproved { get; private set; }
        public Guid BomCategoryId { get; private set; }
        public string? Result { get; private set; }
        public decimal Quantity { get; private set; }

        #endregion

        #region Ctor

        public BomDO() { } // For ORM

        public BomDO(
            string name,
            Guid bomCategoryId,
            string? result,
            decimal quantity)
        {
            Name = name.Trim();
            BomCategoryId = bomCategoryId;
            Result = result?.Trim();
            Quantity = quantity;
            IsApproved = false;
        }

        #endregion

        #region Methods

        public static BomDO Create(
            string name,
            Guid bomCategoryId,
            string? result,
            decimal quantity,
            string createdBy)
        {
            var bom = new BomDO(name, bomCategoryId, result, quantity);

            bom.MarkCreated(createdBy);

            return bom;
        }

        public void Update(
            string name,
            Guid bomCategoryId,
            string? result,
            decimal quantity,
            string updatedBy)
        {
            Name = name.Trim();
            BomCategoryId = bomCategoryId;
            Result = result?.Trim();
            Quantity = quantity;

            MarkUpdated(updatedBy);
        }

        public void Approve(string updatedBy)
        {
            IsApproved = true;
            MarkUpdated(updatedBy);
        }

        public void Reject(string updatedBy)
        {
            IsApproved = false;
            MarkUpdated(updatedBy);
        }

        public void UpdateResult(
            string result,
            string updatedBy)
        {
            Result = result?.Trim();
            MarkUpdated(updatedBy);
        }

        public void UpdateQuantity(
            decimal quantity,
            string updatedBy)
        {
            Quantity = quantity;
            MarkUpdated(updatedBy);
        }

        #endregion
    }
}
