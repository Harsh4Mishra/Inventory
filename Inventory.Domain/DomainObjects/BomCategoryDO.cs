using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class BomCategoryDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public string Name { get; private set; } = default!;

        #endregion

        #region Ctor

        public BomCategoryDO() { } // For ORM

        public BomCategoryDO(string name)
        {
            Name = name.Trim();
        }

        #endregion

        #region Methods

        public static BomCategoryDO Create(
            string name,
            string createdBy)
        {
            var category = new BomCategoryDO(name);

            category.MarkCreated(createdBy);

            return category;
        }

        public void UpdateName(
            string name,
            string updatedBy)
        {
            Name = name.Trim();

            MarkUpdated(updatedBy);
        }

        #endregion
    }
}
