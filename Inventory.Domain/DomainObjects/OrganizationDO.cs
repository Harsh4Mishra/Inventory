using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;

namespace Inventory.Domain.DomainObjects
{
    public sealed class OrganizationDO
        : AuditableDO, IAggregateRoot
    {
        #region Fields

        //private List<EmployeeDO> _employees = new();

        #endregion

        #region Properties

        public string Name { get; private set; } = default!;
        public string? Code { get; private set; }
        public string? Description { get; private set; }
        public bool IsActive { get; private set; } = true;

        // Soft delete properties

        #region Navigation Properties

        //public IReadOnlyCollection<EmployeeDO> Employees => _employees.AsReadOnly();

        #endregion

        #endregion

        #region Ctor

        private OrganizationDO() { } //For ORM

        private OrganizationDO(
            string name,
            string? code,
            string? description,
            bool isActive = true)
        {
            Name = name.Trim();
            Code = code?.Trim();
            Description = description?.Trim();
            IsActive = isActive;
        }

        #endregion

        #region Methods

        public static OrganizationDO Create(
            string name,
            string? code,
            string? description,
            string createdBy)
        {
            var organization = new OrganizationDO(name, code, description);

            organization.MarkCreated(createdBy);

            return organization;
        }

        public void Update(
            string name,
            string? code,
            string? description,
            string updatedBy)
        {
            Name = name.Trim();
            Code = code?.Trim();
            Description = description?.Trim();

            MarkUpdated(updatedBy);
        }

        public void Activate(string updatedBy)
        {
            if (!IsActive)
            {
                IsActive = true;
                MarkUpdated(updatedBy);
            }
        }

        public void Deactivate(string updatedBy)
        {
            if (IsActive)
            {
                IsActive = false;
                MarkUpdated(updatedBy);
            }
        }

        public void SoftDelete(Guid deletedBy)
        {
            if (DeletedOn == null)
            {
                MarkDeleted(deletedBy.ToString()); // Assuming updatedBy is string, adjust if needed
            }
        }

        //public void Restore(string updatedBy)
        //{
        //    if (DeletedOn != null)
        //    {
        //        DeletedOn = null;
        //        DeletedBy = null;
        //        MarkUpdated(updatedBy);
        //    }
        //}


        #endregion
    }
}
