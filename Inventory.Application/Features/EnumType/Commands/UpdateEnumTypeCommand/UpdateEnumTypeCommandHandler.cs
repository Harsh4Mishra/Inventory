using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.EnumType.Commands.UpdateEnumTypeCommand
{
    public class UpdateEnumTypeCommandHandler : IRequestHandler<UpdateEnumTypeCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEnumTypeRepository _enumTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateEnumTypeCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IEnumTypeRepository enumTypeRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _enumTypeRepository = enumTypeRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            UpdateEnumTypeCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load existing enum type or fail if it doesn't exist
                var enumType = await _enumTypeRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No enum type found with Id '{request.Id}'.");

                // 2. Check if the new name would cause a duplicate (if name is being changed)
                if (enumType.Name != request.Name &&
                    await _enumTypeRepository.ExistsByNameAsync(request.Name, cancellationToken))
                {
                    throw new InvalidOperationException($"An enum type named '{request.Name}' already exists.");
                }

                // 3. Identify who's making the change
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
                var userName = "System";

                // 4. Apply updates and persist the changes
                enumType.Update(request.Name, request.Description, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update enum type: {ex.Message}");
            }
        }

        #endregion
    }
}
