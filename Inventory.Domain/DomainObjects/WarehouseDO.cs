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
    public sealed class WarehouseDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public string Name { get; private set; } = default!;
        public JsonDocument? Address { get; private set; }
        public bool IsActive { get; private set; } = default;

        #endregion

        #region Ctor

        public WarehouseDO() { } //For ORM

        public WarehouseDO(
            string name,
            JsonDocument? address)
        {
            Name = name.Trim();
            Address = address;
            IsActive = true;
        }

        #endregion

        #region Methods

        public static WarehouseDO Create(
           string name,
           JsonDocument? address,
           string createdBy)
        {
            var warehouse = new WarehouseDO(name, address);

            warehouse.MarkCreated(createdBy);

            return warehouse;
        }

        public void Update(
            string name,
            JsonDocument? address,
            string updatedBy)
        {
            Name = name.Trim();
            Address = address;

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

        #region IDisposable

        //public override void Dispose()
        //{
        //    Address?.Dispose();
        //    base.Dispose();
        //}

        #endregion
    }
}
