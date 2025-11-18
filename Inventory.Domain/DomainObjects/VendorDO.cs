using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;

namespace Inventory.Domain.DomainObjects
{
    public sealed class VendorDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public string Name { get; private set; } = default!;
        public string Type { get; private set; } = default!;
        public string Contact { get; private set; } = default!;
        public bool IsActive { get; private set; } = default;

        #endregion

        #region Ctor

        public VendorDO() { } //For ORM

        public VendorDO(
            string name,
            string type,
            string contact)
        {
            Name = name.Trim();
            Type = type;
            Contact = contact;
            IsActive = true;
        }

        #endregion

        #region Methods

        public static VendorDO Create(
           string name,
           string type,
           string contact,
           string createdBy)
        {
            var vendor = new VendorDO(name, type, contact);

            vendor.MarkCreated(createdBy);

            return vendor;
        }

        public void Update(
            string name,
            string type,
            string contact,
            string updatedBy)
        {
            Name = name.Trim();
            Type = type;
            Contact = contact;

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
