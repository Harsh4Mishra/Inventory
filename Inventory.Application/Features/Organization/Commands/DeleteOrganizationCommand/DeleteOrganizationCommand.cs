using MediatR;

namespace Inventory.Application.Features.Organization.Commands.DeleteOrganizationCommand
{
    public class DeleteOrganizationCommand : IRequest<Unit>
    {
        #region Properties

        public int Id { get; set; }

        #endregion
    }
}
