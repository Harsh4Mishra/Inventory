
using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.Role.Commands.DeleteRoleCommand
{
    public class DeleteRoleCommandHandler
        : IRequestHandler<DeleteRoleCommand, Unit>
    {
        #region Fields

        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteRoleCommandHandler(
            IRoleRepository RoleRepository,
            IUnitOfWork unitOfWork)
        {
            _roleRepository = RoleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteRoleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the Role or fail if it does'nt exist
                var Role = await _roleRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new InvalidOperationException($"No Role found with Id '{request.Id}'.");

                //2. Remove and persist
                _roleRepository.Remove(Role);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete Role {ex.Message}");
            }
        }

        #endregion
    }
}
