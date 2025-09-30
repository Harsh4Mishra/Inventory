using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;

namespace Inventory.Domain.DomainObjects
{
    public sealed class AppModuleDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public Guid TenantId { get; private set; }
        public string Code { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }
        public bool IsActive { get; private set; } = default;

        #endregion

        #region Ctor

        private AppModuleDO() { } // For ORM

        private AppModuleDO(
            Guid tenantId,
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

        public static AppModuleDO Create(
           Guid tenantId,
           string code,
           string name,
           string? description,
           string createdBy)
        {
            var appModule = new AppModuleDO(tenantId, code, name, description);

            appModule.MarkCreated(createdBy);

            return appModule;
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

        public void ChangeTenant(Guid tenantId, string updatedBy)
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
