using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Aisle.Queries.GetAislesQuery
{
    public sealed record GetAislesQueryResult
    {
        #region Properties

        public Guid Id { get; init; } = default;
        public string Name { get; init; } = default!;
        public Guid WarehouseId { get; init; }
        public Guid StorageSectionId { get; init; }
        public Guid StorageTypeId { get; init; }
        public Guid InventoryTypeId { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; } = default;
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
