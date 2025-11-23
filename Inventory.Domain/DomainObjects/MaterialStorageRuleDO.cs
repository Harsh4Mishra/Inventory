using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class MaterialStorageRuleDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public Guid MaterialId { get; private set; }
        public decimal MinQuantity { get; private set; }
        public decimal ThresholdQuantity { get; private set; }
        public Guid PreferredSectionId { get; private set; }

        #endregion

        #region Ctor

        public MaterialStorageRuleDO() { } // For ORM

        public MaterialStorageRuleDO(
            Guid materialId,
            decimal minQuantity,
            decimal thresholdQuantity,
            Guid preferredSectionId)
        {
            MaterialId = materialId;
            MinQuantity = minQuantity;
            ThresholdQuantity = thresholdQuantity;
            PreferredSectionId = preferredSectionId;
        }

        #endregion

        #region Methods

        public static MaterialStorageRuleDO Create(
            Guid materialId,
            decimal minQuantity,
            decimal thresholdQuantity,
            Guid preferredSectionId,
            string createdBy)
        {
            var rule = new MaterialStorageRuleDO(
                materialId,
                minQuantity,
                thresholdQuantity,
                preferredSectionId);

            rule.MarkCreated(createdBy);

            return rule;
        }

        public void UpdateQuantities(
            decimal minQuantity,
            decimal thresholdQuantity,
            string updatedBy)
        {
            MinQuantity = minQuantity;
            ThresholdQuantity = thresholdQuantity;

            MarkUpdated(updatedBy);
        }

        public void UpdatePreferredSection(
            Guid preferredSectionId,
            string updatedBy)
        {
            PreferredSectionId = preferredSectionId;

            MarkUpdated(updatedBy);
        }

        public void UpdateAll(
            decimal minQuantity,
            decimal thresholdQuantity,
            Guid preferredSectionId,
            string updatedBy)
        {
            MinQuantity = minQuantity;
            ThresholdQuantity = thresholdQuantity;
            PreferredSectionId = preferredSectionId;

            MarkUpdated(updatedBy);
        }

        #endregion
    }
}
