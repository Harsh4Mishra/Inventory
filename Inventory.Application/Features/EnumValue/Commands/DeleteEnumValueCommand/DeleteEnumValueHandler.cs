using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.EnumValue.Commands.DeleteEnumValueCommand
{
    public sealed class DeleteEnumValueHandler
        : IRequestHandler<DeleteEnumValueCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEnumTypeRepository _enumTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteEnumValueHandler(
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

        public async Task<Unit> Handle(DeleteEnumValueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the enum type or fail if it doesn't exist
                var enumType = await _enumTypeRepository.GetByIdToMutateAsync(request.EnumTypeId, cancellationToken)
                    ?? throw new InvalidOperationException($"No enum type found with Id '{request.EnumTypeId}'.");

                // 2. Delete and persist
                enumType.DeleteEnumValue(request.Id);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete enum value: {ex.Message}");
            }
        }

        #endregion
    }
}
