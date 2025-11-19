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
    public sealed class VerifiedMaterialDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public Guid MaterialBatchId { get; private set; }
        public bool IsAllotted { get; private set; } = false;
        public decimal Quantity { get; private set; }
        public Guid? EmpId { get; private set; }
        public JsonDocument? Specification { get; private set; }
        public bool? IsQualified { get; private set; }
        public string? Reason { get; private set; }

        #endregion

        #region Ctor

        public VerifiedMaterialDO() { } // For ORM

        public VerifiedMaterialDO(
            Guid materialBatchId,
            decimal quantity,
            Guid? empId = null,
            JsonDocument? specification = null,
            bool? isQualified = null,
            string? reason = null)
        {
            MaterialBatchId = materialBatchId;
            Quantity = quantity;
            EmpId = empId;
            Specification = specification;
            IsQualified = isQualified;
            Reason = reason?.Trim();
            IsAllotted = false;
        }

        #endregion

        #region Methods

        public static VerifiedMaterialDO Create(
            Guid materialBatchId,
            decimal quantity,
            Guid? empId = null,
            JsonDocument? specification = null,
            bool? isQualified = null,
            string? reason = null,
            string createdBy = "system")
        {
            var verifiedMaterial = new VerifiedMaterialDO(
                materialBatchId,
                quantity,
                empId,
                specification,
                isQualified,
                reason);

            verifiedMaterial.MarkCreated(createdBy);

            return verifiedMaterial;
        }

        public void UpdateVerification(
            bool? isQualified,
            string? reason,
            Guid? empId = null,
            JsonDocument? specification = null,
            string updatedBy = "system")
        {
            IsQualified = isQualified;
            Reason = reason?.Trim();
            EmpId = empId;
            Specification = specification;

            MarkUpdated(updatedBy);
        }

        public void Allot(string updatedBy = "system")
        {
            if (IsAllotted)
                throw new InvalidOperationException("Material is already allotted");

            IsAllotted = true;
            MarkUpdated(updatedBy);
        }

        public void ReleaseAllotment(string updatedBy = "system")
        {
            if (!IsAllotted)
                throw new InvalidOperationException("Material is not allotted");

            IsAllotted = false;
            MarkUpdated(updatedBy);
        }

        public void UpdateQuantity(decimal quantity, string updatedBy = "system")
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            Quantity = quantity;
            MarkUpdated(updatedBy);
        }

        #endregion

        #region IDisposable

        //public override void Dispose()
        //{
        //    Specification?.Dispose();
        //    base.Dispose();
        //}

        #endregion
    }
}
