using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;

namespace Inventory.Application.Features.EnumType.Commands.DeleteEnumTypeCommand
{
    public class DeleteEnumTypeCommandHandler : IRequestHandler<DeleteEnumTypeCommand, Unit>
    {
        #region Fields

        private readonly IEnumTypeRepository _enumTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteEnumTypeCommandHandler(
            IEnumTypeRepository enumTypeRepository,
            IUnitOfWork unitOfWork)
        {
            _enumTypeRepository = enumTypeRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteEnumTypeCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the enum type or fail if it doesn't exist
                var enumType = await _enumTypeRepository.GetByIdToMutateAsync((int)request.Id!, cancellationToken)
                    ?? throw new InvalidOperationException($"No enum type found with Id '{request.Id}'.");

                // 2. Check if the enum type has any values (optional business rule)
                if (enumType.EnumValues.Any())
                {
                    throw new InvalidOperationException($"Cannot delete enum type '{enumType.Name}' because it has associated values.");
                }

                // 3. Remove and persist
                _enumTypeRepository.Remove(enumType);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete enum type: {ex.Message}");
            }
        }

        #endregion
    }
}
