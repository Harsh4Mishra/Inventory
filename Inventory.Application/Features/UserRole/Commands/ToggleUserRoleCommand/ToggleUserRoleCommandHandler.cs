using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.UserRole.Commands.ToggleUserRoleCommand
{
    public class ToggleUserRoleCommandHandler
        : IRequestHandler<ToggleUserRoleCommand, Unit>
    {
        #region Fields

        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public ToggleUserRoleCommandHandler(
            IUserRoleRepository userRoleRepository,
            IUnitOfWork unitOfWork)
        {
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            ToggleUserRoleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the UserRole or fail if it doesn't exist
                var userRole = await _userRoleRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No user-role assignment found with Id '{request.Id}'.");

                //2. Toggle status
                if (request.IsActive)
                {
                    userRole.Activate("System"); // TODO: Replace with actual user
                }
                else
                {
                    userRole.Deactivate("System"); // TODO: Replace with actual user
                }

                //3. Update and persist
                _userRoleRepository.Update(userRole);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to toggle user-role assignment status: {ex.Message}");
            }
        }

        #endregion
    }
}
