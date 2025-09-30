using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;

namespace Inventory.Domain.DomainObjects
{
    public sealed class RolePermissionDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public Guid RoleId { get; private set; }
        public Guid ModuleId { get; private set; }
        public Guid PermissionId { get; private set; }
        public bool IsActive { get; private set; } = default;

        #endregion

        #region Ctor

        private RolePermissionDO() { } // For ORM

        private RolePermissionDO(
            Guid roleId,
            Guid moduleId,
            Guid permissionId)
        {
            RoleId = roleId;
            ModuleId = moduleId;
            PermissionId = permissionId;
            IsActive = true;
        }

        #endregion

        #region Methods

        public static RolePermissionDO Create(
           Guid roleId,
           Guid moduleId,
           Guid permissionId,
           string createdBy)
        {
            var rolePermission = new RolePermissionDO(roleId, moduleId, permissionId);

            rolePermission.MarkCreated(createdBy);

            return rolePermission;
        }

        public void Update(
            Guid moduleId,
            Guid permissionId,
            string updatedBy)
        {
            ModuleId = moduleId;
            PermissionId = permissionId;

            MarkUpdated(updatedBy);
        }

        public void ChangeRole(Guid roleId, string updatedBy)
        {
            RoleId = roleId;
            MarkUpdated(updatedBy);
        }

        public void ChangeModule(Guid moduleId, string updatedBy)
        {
            ModuleId = moduleId;
            MarkUpdated(updatedBy);
        }

        public void ChangePermission(Guid permissionId, string updatedBy)
        {
            PermissionId = permissionId;
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
