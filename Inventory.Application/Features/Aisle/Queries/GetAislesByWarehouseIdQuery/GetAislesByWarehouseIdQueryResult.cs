using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Aisle.Queries.GetAislesByWarehouseIdQuery
{
    public sealed record GetAislesByWarehouseIdQueryResult
    {
        #region Properties

        public int Id { get; init; } = default;
        public string Name { get; init; } = default!;
        public int WarehouseId { get; init; }
        public int StorageSectionId { get; init; }
        public int StorageTypeId { get; init; }
        public int InventoryTypeId { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; } = default;
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
