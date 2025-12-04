
using MediatR;

namespace Inventory.Application.Features.User.Commands.DeleteUserCommand
{
    public sealed record DeleteUserCommand : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }

        #endregion
    }
}
