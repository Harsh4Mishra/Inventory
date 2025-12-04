using Inventory.Domain.Enums;
using Inventory.Domain.ValueObjects;
using MediatR;

namespace Inventory.Application.Features.User.Commands.CreateUserCommand
{
    public sealed record CreateUserCommand : IRequest<int>
    {
        #region Properties

        public string Name { get; init; } = default!;
        public PhoneVO PhoneNo { get; init; } = default!;
        public EmailVO EmailId { get; init; } = default!;
        public DateOnly DateOfBirth { get; init; }
        public Gender Gender { get; init; }

        #endregion
    }
}
