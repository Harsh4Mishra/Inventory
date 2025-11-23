using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomCategory.Commands.UpdateBomCategoryCommand
{
    public class UpdateBomCategoryCommandHandler : IRequestHandler<UpdateBomCategoryCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBomCategoryRepository _bomCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateBomCategoryCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IBomCategoryRepository bomCategoryRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _bomCategoryRepository = bomCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateBomCategoryCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load existing BOM category or fail if it doesn't exist
                var category = await _bomCategoryRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No BOM category found with Id '{request.Id}'.");

                // 2. Check if new name already exists (excluding current category)
                var existingCategory = await _bomCategoryRepository.GetByNameAsync(request.Name, cancellationToken);
                if (existingCategory != null && existingCategory.Id != request.Id)
                {
                    throw new InvalidOperationException($"A BOM category named '{request.Name}' already exists.");
                }

                // 3. Identify who's making the change
                var userName = "System";

                // 4. Apply updates and persist the changes
                category.UpdateName(request.Name, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update BOM category: {ex.Message}");
            }
        }

        #endregion
    }
}
