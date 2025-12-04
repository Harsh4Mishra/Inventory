using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomCategory.Commands.CreateBomCategoryCommand
{
    public class CreateBomCategoryCommandHandler : IRequestHandler<CreateBomCategoryCommand, int>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBomCategoryRepository _bomCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateBomCategoryCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IBomCategoryRepository bomCategoryRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _bomCategoryRepository = bomCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<int> Handle(
            CreateBomCategoryCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Prevent duplicates
                if (await _bomCategoryRepository.ExistsByNameAsync(request.Name, cancellationToken))
                {
                    throw new InvalidOperationException($"A BOM category named '{request.Name}' already exists.");
                }

                // 2. Identify the creator
                var userName = "System"; // TODO: Replace with actual user identification

                // 3. Create and persist the new BOM category
                var category = BomCategoryDO.Create(
                    request.Name,
                    userName);

                _bomCategoryRepository.Add(category);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return category.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create BOM category: {ex.Message}");
            }
        }

        #endregion
    }
}
