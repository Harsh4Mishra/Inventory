using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.Role.Commands.UpdateRoleCommand
{
    public class UpdateRoleCommandHandler
        : IRequestHandler<UpdateRoleCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRoleRepository _RoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateRoleCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IRoleRepository RoleRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _RoleRepository = RoleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateRoleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load existing Role or fail if it doesn't exist
                var Role = await _RoleRepository.GetByIdToMutateAsync(request.Id, cancellationToken) ?? throw new InvalidOperationException($"No Role found with Id '{request.Id}'.");

                //2. Identify who’s making the change
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
                var userName = "System";

                //3. Apply updates and persist the changes
                Role.Update(request.Name, request.Description, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update Role {ex.Message}");
            }
        }

        #endregion
    }
}
