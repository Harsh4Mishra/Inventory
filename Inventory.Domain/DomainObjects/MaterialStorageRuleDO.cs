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

        public int MaterialId { get; private set; }
        public decimal MinQuantity { get; private set; }
        public decimal ThresholdQuantity { get; private set; }
        public int PreferredSectionId { get; private set; }

        #endregion

        #region Ctor

        public MaterialStorageRuleDO() { } // For ORM

        public MaterialStorageRuleDO(
            int materialId,
            decimal minQuantity,
            decimal thresholdQuantity,
            int preferredSectionId)
        {
            MaterialId = materialId;
            MinQuantity = minQuantity;
            ThresholdQuantity = thresholdQuantity;
            PreferredSectionId = preferredSectionId;
        }

        #endregion

        #region Methods

        public static MaterialStorageRuleDO Create(
            int materialId,
            decimal minQuantity,
            decimal thresholdQuantity,
            int preferredSectionId,
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
            int preferredSectionId,
            string updatedBy)
        {
            PreferredSectionId = preferredSectionId;

            MarkUpdated(updatedBy);
        }

        public void UpdateAll(
            decimal minQuantity,
            decimal thresholdQuantity,
            int preferredSectionId,
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
