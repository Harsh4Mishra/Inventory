using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomCategory.Commands.DeleteBomCategoryCommand
{
    public class DeleteBomCategoryCommandHandler : IRequestHandler<DeleteBomCategoryCommand, Unit>
    {
        #region Fields

        private readonly IBomCategoryRepository _bomCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteBomCategoryCommandHandler(
            IBomCategoryRepository bomCategoryRepository,
            IUnitOfWork unitOfWork)
        {
            _bomCategoryRepository = bomCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteBomCategoryCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the BOM category or fail if it doesn't exist
                var category = await _bomCategoryRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No BOM category found with Id '{request.Id}'.");

                // 2. Remove and persist
                _bomCategoryRepository.Remove(category);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete BOM category: {ex.Message}");
            }
        }

        #endregion
    }
}
