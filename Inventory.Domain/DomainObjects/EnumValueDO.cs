using Inventory.Domain.Primitives;

namespace Inventory.Domain.DomainObjects
{
    public sealed class EnumValueDO
        : AuditableDO
    {
        #region Properties
        public int EnumTypeId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }
        #endregion

        #region Ctor
        private EnumValueDO() { } // For ORM

        private EnumValueDO(
            int enumTypeId,
            string name,
            string code,
            string description)
        {
            EnumTypeId = enumTypeId;
            Name = name.Trim();
            Code = code.Trim();
            Description = description?.Trim();
            IsActive = true;
        }
        #endregion

        #region Methods
        internal static EnumValueDO Create(
            int enumTypeId,
            string name,
            string code,
            string description,
            string createdBy)
        {
            var enumValue = new EnumValueDO(enumTypeId, name, code, description);
            enumValue.MarkCreated(createdBy);
            return enumValue;
        }

        internal void Update(
            string name,
            string description,
            string updatedBy)
        {
            Name = name.Trim();
            Description = description?.Trim();
            MarkUpdated(updatedBy);
        }

        internal void Activate(string updatedBy)
        {
            IsActive = true;
            MarkUpdated(updatedBy);
        }

        internal void Deactivate(string updatedBy)
        {
            IsActive = false;
            MarkUpdated(updatedBy);
        }


        #endregion
    }
}
