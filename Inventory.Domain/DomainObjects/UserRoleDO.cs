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

        public int UserId { get; private set; }
        public int RoleId { get; private set; }
        public bool IsActive { get; private set; } = default;

        #endregion

        #region Ctor

        private UserRoleDO() { } // For ORM

        private UserRoleDO(
            int userId,
            int roleId)
        {
            UserId = userId;
            RoleId = roleId;
            IsActive = true;
        }

        #endregion

        #region Methods

        public static UserRoleDO Create(
           int userId,
           int roleId,
           string createdBy)
        {
            var userRole = new UserRoleDO(userId, roleId);

            userRole.MarkCreated(createdBy);

            return userRole;
        }

        public void Update(
            int roleId,
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

        public void AssignToUser(int userId, string updatedBy)
        {
            UserId = userId;

            MarkUpdated(updatedBy);
        }

        public void AssignToRole(int roleId, string updatedBy)
        {
            RoleId = roleId;

            MarkUpdated(updatedBy);
        }

        #endregion
    }
}
