using Inventory.Domain.Enums;
using Inventory.Domain.ValueObjects;
using MediatR;

namespace Inventory.Application.Features.User.Commands.UpdateUserCommand
{
    public sealed record UpdateUserCommand : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string PhoneNo { get; set; } = default!;
        public string EmailId { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }

        #endregion
    }
}
