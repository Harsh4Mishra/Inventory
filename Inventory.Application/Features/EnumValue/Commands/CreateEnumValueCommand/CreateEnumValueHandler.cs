using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.EnumValue.Commands.CreateEnumValueCommand
{
    public class CreateEnumValueHandler
        : IRequestHandler<CreateEnumValueCommand, Guid>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumTypeRepository _enumTypeRepository;

        #endregion

        #region Ctor

        public CreateEnumValueHandler(
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

        public async Task<Guid> Handle(
            CreateEnumValueCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load existing enum type or fail if it doesn't exist
                var enumType = await _enumTypeRepository.GetByIdToMutateAsync(request.EnumTypeId, cancellationToken)
                    ?? throw new InvalidOperationException($"No enum type found with Id '{request.EnumTypeId}'.");

                // 2. Identify the creator
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Could not determine the current user.");
                var userName = "System";

                // 3. Generate the next available enum value code
                var code = "ENV001"; //work on this

                // 4. Create and persist the new enum value
                var enumValue = enumType.CreateEnumValue(request.Name, code, request.Description, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return enumValue.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create enum value: {ex.Message}");
            }
        }

        #endregion
    }
}
