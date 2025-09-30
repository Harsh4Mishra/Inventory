using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class UserRoleDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public Guid UserId { get; private set; }
        public Guid RoleId { get; private set; }
        public bool IsActive { get; private set; } = default;

        #endregion

        #region Ctor

        private UserRoleDO() { } // For ORM

        private UserRoleDO(
            Guid userId,
            Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
            IsActive = true;
        }

        #endregion

        #region Methods

        public static UserRoleDO Create(
           Guid userId,
           Guid roleId,
           string createdBy)
        {
            var userRole = new UserRoleDO(userId, roleId);

            userRole.MarkCreated(createdBy);

            return userRole;
        }

        public void Update(
            Guid roleId,
            string updatedBy)
        {
            RoleId = roleId;

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

        public void AssignToUser(Guid userId, string updatedBy)
        {
            UserId = userId;

            MarkUpdated(updatedBy);
        }

        public void AssignToRole(Guid roleId, string updatedBy)
        {
            RoleId = roleId;

            MarkUpdated(updatedBy);
        }

        #endregion
    }
}
