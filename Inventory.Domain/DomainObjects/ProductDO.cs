using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class ProductDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public string Name { get; private set; } = default!;
        public string Sku { get; private set; } = default!;
        public int BomId { get; private set; }
        public bool IsActive { get; private set; } = default;

        #endregion

        #region Ctor

        public ProductDO() { } // For ORM

        public ProductDO(
            string name,
            string sku,
            int bomId)
        {
            Name = name.Trim();
            Sku = sku.Trim();
            BomId = bomId;
            IsActive = true;
        }

        #endregion

        #region Methods

        public static ProductDO Create(
           string name,
           string sku,
           int bomId,
           string createdBy)
        {
            var product = new ProductDO(name, sku, bomId);
            product.MarkCreated(createdBy);
            return product;
        }

        public void Update(
            string name,
            string sku,
            int bomId,
            string updatedBy)
        {
            Name = name.Trim();
            Sku = sku.Trim();
            BomId = bomId;

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
