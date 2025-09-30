using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.UserRole.Commands.UpdateUserRoleCommand
{
    public class UpdateUserRoleCommandHandler
        : IRequestHandler<UpdateUserRoleCommand, Unit>
    {
        #region Fields

        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateUserRoleCommandHandler(
            IUserRoleRepository userRoleRepository,
            IRoleRepository roleRepository,
            IUnitOfWork unitOfWork)
        {
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            UpdateUserRoleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the UserRole or fail if it doesn't exist
                var userRole = await _userRoleRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No user-role assignment found with Id '{request.Id}'.");

                //2. Validate new role exists and is active
                var role = await _roleRepository.GetByIdAsync(request.RoleId, cancellationToken);
                if (role == null)
                {
                    throw new InvalidOperationException($"Role with ID '{request.RoleId}' not found or inactive.");
                }

                //3. Update and persist
                userRole.Update(request.RoleId, "System"); // TODO: Replace with actual user
                _userRoleRepository.Update(userRole);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update user-role assignment: {ex.Message}");
            }
        }

        #endregion
    }
}
