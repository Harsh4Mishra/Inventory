using Inventory.Domain.Enums;
using Inventory.Domain.ValueObjects;
using MediatR;

namespace Inventory.Application.Features.User.Commands.CreateUserCommand
{
    public sealed record CreateUserCommand : IRequest<int>
    {
        #region Properties

        public string Name { get; init; } = default!;
        public string PhoneNo { get; init; } = default!;
        public string EmailId { get; init; } = default!;
        public DateTime DateOfBirth { get; init; }
        public int Gender { get; init; }

        #endregion
    }
}
