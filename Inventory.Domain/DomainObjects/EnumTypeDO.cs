using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System.Xml.Linq;

namespace Inventory.Domain.DomainObjects
{
    public sealed class EnumTypeDO
        : AuditableDO, IAggregateRoot
    {
        #region Fields
        private List<EnumValueDO> _enumValues = new();
        #endregion

        #region Properties
        public string Name { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }
        #region Navigation Properties
        public IReadOnlyCollection<EnumValueDO> EnumValues => _enumValues.AsReadOnly();
        #endregion
        #endregion

        #region Ctor
        private EnumTypeDO() { } // For ORM

        private EnumTypeDO(
            string name,
            string code,
            string description)
        {
            Name = name.Trim();
            Code = code.Trim();
            Description = description?.Trim();
            IsActive = true;
        }
        #endregion

        #region Methods
        public static EnumTypeDO Create(
            string name,
            string code,
            string description,
            string createdBy)
        {
            var enumType = new EnumTypeDO(name, code, description);
            enumType.MarkCreated(createdBy);
            return enumType;
        }

        public void Update(
            string name,
            string description,
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
        public void DeleteEnumValue(Guid enumValueId)
        {
            var enumValue = _enumValues.FirstOrDefault(ev => ev.Id == enumValueId)
                ?? throw new InvalidOperationException("Enum value not found");

            _enumValues.Remove(enumValue);
        }
        public EnumValueDO CreateEnumValue(
            string name,
            string code,
            string description,
            string createdBy)
        {
            if (!IsActive)
                throw new InvalidOperationException("Cannot add value to inactive enum type");

            if (_enumValues.Any(ev => ev.Name == name))
                throw new InvalidOperationException("Enum value with same name already exists");

            var enumValue = EnumValueDO.Create(Id, name, code, description, createdBy);
            _enumValues.Add(enumValue);
            return enumValue;
        }

        public EnumValueDO UpdateEnumValue(
            Guid enumValueId,
            string name,
            string description,
            string updatedBy)
        {
            var enumValue = _enumValues.FirstOrDefault(ev => ev.Id == enumValueId)
                ?? throw new InvalidOperationException("Enum value not found");

            enumValue.Update(name, description, updatedBy);
            return enumValue;
        }

        public void ActivateEnumValue(Guid enumValueId, string updatedBy)
        {
            if (!IsActive)
                throw new InvalidOperationException("Cannot activate value of inactive enum type");

            var enumValue = _enumValues.FirstOrDefault(ev => ev.Id == enumValueId)
                ?? throw new InvalidOperationException("Enum value not found");

            enumValue.Activate(updatedBy);
        }

        public void DeactivateEnumValue(Guid enumValueId, string updatedBy)
        {
            var enumValue = _enumValues.FirstOrDefault(ev => ev.Id == enumValueId)
                ?? throw new InvalidOperationException("Enum value not found");

            enumValue.Deactivate(updatedBy);
        }
        #endregion
    }
}
