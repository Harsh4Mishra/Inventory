using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.User.Commands.ToggleUserStatusCommand
{
    public sealed class ToggleUserStatusCommandHandler : IRequestHandler<ToggleUserStatusCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public ToggleUserStatusCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            ToggleUserStatusCommand request,
            CancellationToken cancellationToken)
        {
            //1. Load the user or fail if it does'nt exist
            var user = await _userRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                ?? throw new InvalidOperationException($"User not found with ID: {request.Id}");

            //2. Identify who’s performing the toggle
            //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
            var userName = "System"; // TODO: Replace with actual user identification

            //3. Toggle status
            if (request.IsActive)
            {
                user.Activate(userName);
            }
            else
            {
                user.Deactivate(userName);
            }

            //4. Persist
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        #endregion
    }
}
