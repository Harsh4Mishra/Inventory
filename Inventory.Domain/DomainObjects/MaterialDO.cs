using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class MaterialDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public string Sku { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public string? Category { get; private set; }
        public string? Subcategory { get; private set; }
        public string? CasNumber { get; private set; }
        public string? Description { get; private set; }
        public bool IsActive { get; private set; } = default;

        #endregion

        #region Ctor

        public MaterialDO() { } //For ORM

        public MaterialDO(
            string sku,
            string name,
            string? category,
            string? subcategory,
            string? casNumber,
            string? description)
        {
            Sku = sku.Trim().ToUpper();
            Name = name.Trim();
            Category = category?.Trim();
            Subcategory = subcategory?.Trim();
            CasNumber = casNumber?.Trim();
            Description = description?.Trim();
            IsActive = true;
        }

        #endregion

        #region Methods

        public static MaterialDO Create(
           string sku,
           string name,
           string? category,
           string? subcategory,
           string? casNumber,
           string? description,
           string createdBy)
        {
            var material = new MaterialDO(sku, name, category, subcategory, casNumber, description);

            material.MarkCreated(createdBy);

            return material;
        }

        public void Update(
            string name,
            string? category,
            string? subcategory,
            string? casNumber,
            string? description,
            string updatedBy)
        {
            Name = name.Trim();
            Category = category?.Trim();
            Subcategory = subcategory?.Trim();
            CasNumber = casNumber?.Trim();
            Description = description?.Trim();

            MarkUpdated(updatedBy);
        }

        public void UpdateSku(
            string sku,
            string updatedBy)
        {
            Sku = sku.Trim().ToUpper();
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
