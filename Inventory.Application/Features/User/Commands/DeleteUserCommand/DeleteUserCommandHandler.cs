using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.User.Commands.DeleteUserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        #region Fields

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public DeleteUserCommandHandler(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            DeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the user or fail if it doesn't exist
                var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No user found with Id '{request.Id}'.");

                // 2. Perform any pre-deletion validations
                if (user.IsActive)
                {
                    throw new InvalidOperationException("Cannot delete an active user. Deactivate first.");
                }

                // 3. Remove and persist
                _userRepository.Remove(user);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete user: {ex.Message}");
            }
        }

        #endregion
    }
}
