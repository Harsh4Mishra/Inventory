
using Inventory.Domain.Enums;
using Inventory.Domain.ValueObjects;

namespace Inventory.Application.Features.User.Queries.GetActiveUsersQuery
{
    public sealed record GetActiveUsersQueryResult
    {
        #region Properties

        public int Id { get; init; }
        public string Name { get; init; } = default!;
        public PhoneVO PhoneNo { get; init; } = default!;
        public EmailVO EmailId { get; init; } = default!;
        public DateTime DateOfBirth { get; init; }
        public Gender Gender { get; init; }
        public string CreatedBy { get; init; } = default!;
        public DateTime CreatedOn { get; init; }
        public string? UpdatedBy { get; init; }
        public DateTime? UpdatedOn { get; init; }

        #endregion
    }
}
