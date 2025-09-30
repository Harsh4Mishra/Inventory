using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;

namespace Inventory.Domain.DomainObjects
{
    public sealed class RoleDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public string Name { get; private set; } = default!;
        public string Code { get; private set; } = default!;
        public string? Description { get; private set; }
        public bool IsActive { get; private set; } = default;

        #endregion

        #region Ctor

        public RoleDO() { } //For ORM

        public RoleDO(
            string name,
            string code,
            string? description)
        {
            Name = name.Trim();
            Code = code;
            Description = description?.Trim();
            IsActive = true;
        }

        #endregion

        #region Methods

        public static RoleDO Create(
           string name,
           string code,
           string? description,
           string createdBy)
        {
            var role = new RoleDO(name, code, description);

            role.MarkCreated(createdBy);

            return role;
        }

        public void Update(
            string name,
            string? description,
            string updatedBy)
        {
            Name = name.Trim();
            Description = description?.Trim();

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