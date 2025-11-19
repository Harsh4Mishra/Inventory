using Inventory.Domain.Interfaces;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.DomainObjects
{
    public sealed class StorageSectionDO
        : AuditableDO, IAggregateRoot
    {
        #region Properties

        public string Name { get; private set; } = default!;
        public string? TemperatureRange { get; private set; }
        public string? Description { get; private set; }
        public bool IsActive { get; private set; } = default;

        #endregion

        #region Ctor

        public StorageSectionDO() { } //For ORM

        public StorageSectionDO(
            string name,
            string? temperatureRange,
            string? description)
        {
            Name = name.Trim();
            TemperatureRange = temperatureRange?.Trim();
            Description = description?.Trim();
            IsActive = true;
        }

        #endregion

        #region Methods

        public static StorageSectionDO Create(
           string name,
           string? temperatureRange,
           string? description,
           string createdBy)
        {
            var storageSection = new StorageSectionDO(name, temperatureRange, description);

            storageSection.MarkCreated(createdBy);

            return storageSection;
        }

        public void Update(
            string name,
            string? temperatureRange,
            string? description,
            string updatedBy)
        {
            Name = name.Trim();
            TemperatureRange = temperatureRange?.Trim();
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
