using Inventory.Domain.Enums;
using Inventory.Domain.ValueObjects;
using MediatR;

namespace Inventory.Application.Features.User.Commands.UpdateUserCommand
{
    public sealed record UpdateUserCommand : IRequest<Unit>
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public PhoneVO PhoneNo { get; set; } = default!;
        public EmailVO EmailId { get; set; } = default!;
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        #endregion
    }
}
