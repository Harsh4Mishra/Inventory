using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.EnumValue.Commands.UpdateEnumValueCommand
{
    public class UpdateEnumValueHandler
        : IRequestHandler<UpdateEnumValueCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEnumTypeRepository _enumTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateEnumValueHandler(
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
            UpdateEnumValueCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load existing enum type or fail if it doesn't exist
                var enumType = await _enumTypeRepository.GetByIdToMutateAsync(request.EnumTypeId, cancellationToken)
                    ?? throw new InvalidOperationException($"No enum type found with Id '{request.EnumTypeId}'.");

                // 2. Identify who's making the change
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
                var userName = "System";

                // 3. Apply updates on enum value
                enumType.UpdateEnumValue(request.Id, request.Name, request.Description, userName);

                // 4. Persist
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update enum value: {ex.Message}");
            }
        }

        #endregion
    }
}
