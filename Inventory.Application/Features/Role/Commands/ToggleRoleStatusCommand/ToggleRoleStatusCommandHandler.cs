using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.Role.Commands.ToggleRoleStatusCommand
{
    public class ToggleRoleStatusCommandHandler : IRequestHandler<ToggleRoleStatusCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public ToggleRoleStatusCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IRoleRepository roleRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            ToggleRoleStatusCommand request,
            CancellationToken cancellationToken)
        {
            //1. Load the industry or fail if it does'nt exist
            var role = await _roleRepository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new InvalidOperationException($"No role found with Id '{request.Id}'.");

            //2. Identify who’s performing the toggle
            //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
            var userName = "System"; // TODO: Replace with actual user identification

            if (request.IsActive)
            {
                role.Activate(userName);
            }
            else
            {
                role.Deactivate(userName);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        #endregion
    }
}
