using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class MaterialBatchDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public int MaterialId { get; private set; }
        public int? VendorId { get; private set; }
        public string BatchCode { get; private set; } = default!;
        public string? Barcode { get; private set; }
        public DateTime? ManufactureDate { get; private set; }
        public DateTime? ExpiryDate { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal RemainingQuantity { get; private set; }
        public int? StorageSectionId { get; private set; }
        public string? LocationText { get; private set; }
        public bool IsActive { get; private set; } = default;

        // Navigation properties
        public MaterialDO? Material { get; private set; }
        public VendorDO? Vendor { get; private set; }

        #endregion

        #region Ctor

        public MaterialBatchDO() { } //For ORM

        public MaterialBatchDO(
            int materialId,
            int? vendorId,
            string batchCode,
            string? barcode,
            DateTime? manufactureDate,
            DateTime? expiryDate,
            decimal quantity,
            int? storageSectionId,
            string? locationText)
        {
            MaterialId = materialId;
            VendorId = vendorId;
            BatchCode = batchCode.Trim();
            Barcode = barcode?.Trim();
            ManufactureDate = manufactureDate;
            ExpiryDate = expiryDate;
            Quantity = quantity;
            RemainingQuantity = quantity; // Initially remaining equals total quantity
            StorageSectionId = storageSectionId;
            LocationText = locationText?.Trim();
            IsActive = true;
        }

        #endregion

        #region Methods

        public static MaterialBatchDO Create(
           int materialId,
           int? vendorId,
           string batchCode,
           string? barcode,
           DateTime? manufactureDate,
           DateTime? expiryDate,
           decimal quantity,
           int? storageSectionId,
           string? locationText,
           string createdBy)
        {
            var batch = new MaterialBatchDO(
                materialId, vendorId, batchCode, barcode,
                manufactureDate, expiryDate, quantity,
                storageSectionId, locationText);

            batch.MarkCreated(createdBy);

            return batch;
        }

        public void Update(
            int? vendorId,
            string? barcode,
            DateTime? manufactureDate,
            DateTime? expiryDate,
            int? storageSectionId,
            string? locationText,
            string updatedBy)
        {
            VendorId = vendorId;
            Barcode = barcode?.Trim();
            ManufactureDate = manufactureDate;
            ExpiryDate = expiryDate;
            StorageSectionId = storageSectionId;
            LocationText = locationText?.Trim();

            MarkUpdated(updatedBy);
        }

        public void UpdateBatchCode(
            string batchCode,
            string updatedBy)
        {
            BatchCode = batchCode.Trim();
            MarkUpdated(updatedBy);
        }

        public void UpdateQuantity(
            decimal newQuantity,
            string updatedBy)
        {
            if (newQuantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");

            var quantityDifference = newQuantity - Quantity;
            Quantity = newQuantity;
            RemainingQuantity += quantityDifference;

            if (RemainingQuantity < 0)
                RemainingQuantity = 0;

            MarkUpdated(updatedBy);
        }

        public void ConsumeQuantity(
            decimal consumedQuantity,
            string updatedBy)
        {
            if (consumedQuantity <= 0)
                throw new ArgumentException("Consumed quantity must be positive.");

            if (consumedQuantity > RemainingQuantity)
                throw new InvalidOperationException($"Insufficient quantity. Available: {RemainingQuantity}, Requested: {consumedQuantity}");

            RemainingQuantity -= consumedQuantity;
            MarkUpdated(updatedBy);
        }

        public void AdjustRemainingQuantity(
            decimal adjustment,
            string updatedBy)
        {
            RemainingQuantity += adjustment;

            if (RemainingQuantity < 0)
                RemainingQuantity = 0;

            if (RemainingQuantity > Quantity)
                RemainingQuantity = Quantity;

            MarkUpdated(updatedBy);
        }

        public void Activate(string updatedBy)
        {
            IsActive = true;
            MarkUpdated(updatedBy);
        }

        public void Deactivate(string updatedBy)
        {
            IsActive = false;
            MarkUpdated(updatedBy);
        }

        #endregion
    }
}
