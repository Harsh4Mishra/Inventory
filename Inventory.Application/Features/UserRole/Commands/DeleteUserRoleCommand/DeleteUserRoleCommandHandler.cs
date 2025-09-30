using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.UserRole.Commands.DeleteUserRoleCommand
{
    public class DeleteUserRoleCommandHandler
        : IRequestHandler<DeleteUserRoleCommand, Unit>
    {
        #region Fields

        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteUserRoleCommandHandler(
            IUserRoleRepository userRoleRepository,
            IUnitOfWork unitOfWork)
        {
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteUserRoleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the UserRole or fail if it doesn't exist
                var userRole = await _userRoleRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No user-role assignment found with Id '{request.Id}'.");

                //2. Remove and persist
                _userRoleRepository.Remove(userRole);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete user-role assignment: {ex.Message}");
            }
        }

        #endregion
    }
}
