using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;

namespace Inventory.Domain.DomainObjects
{
    public sealed class PermissionDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public int TenantId { get; private set; }
        public string Code { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }
        public bool IsActive { get; private set; } = default;

        #endregion

        #region Ctor

        private PermissionDO() { } // For ORM

        private PermissionDO(
            int tenantId,
            string code,
            string name,
            string? description)
        {
            TenantId = tenantId;
            Code = code.Trim();
            Name = name.Trim();
            Description = description?.Trim();
            IsActive = true;
        }

        #endregion

        #region Methods

        public static PermissionDO Create(
           int tenantId,
           string code,
           string name,
           string? description,
           string createdBy)
        {
            var permission = new PermissionDO(tenantId, code, name, description);

            permission.MarkCreated(createdBy);

            return permission;
        }

        public void Update(
            string code,
            string name,
            string? description,
            string updatedBy)
        {
            Code = code.Trim();
            Name = name.Trim();
            Description = description?.Trim();

            MarkUpdated(updatedBy);
        }

        public void ChangeTenant(int tenantId, string updatedBy)
        {
            TenantId = tenantId;
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
