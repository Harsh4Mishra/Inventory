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

namespace Inventory.Application.Features.BomItem.Commands.CreateBomItemCommand
{
    public class CreateBomItemCommandHandler : IRequestHandler<CreateBomItemCommand, Guid>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBomItemRepository _bomItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateBomItemCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IBomItemRepository bomItemRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _bomItemRepository = bomItemRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Guid> Handle(
            CreateBomItemCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Validate quantity
                if (request.Quantity <= 0)
                {
                    throw new InvalidOperationException("Quantity must be greater than zero.");
                }

                // 2. Check if item already exists in BOM (prevent duplicates)
                var existingItems = await _bomItemRepository.GetByBomIdAsync(request.BomId, cancellationToken);
                if (existingItems.Any(item => item.MaterialBatchId == request.MaterialBatchId && item.WarehouseItemId == request.WarehouseItemId))
                {
                    throw new InvalidOperationException("This item already exists in the BOM.");
                }

                // 3. Identify the creator
                var userName = "System"; // TODO: Replace with actual user identification

                // 4. Create and persist the new BOM item
                var bomItem = BomItemDO.Create(
                    request.BomId,
                    request.MaterialBatchId,
                    request.WarehouseItemId,
                    request.Quantity,
                    userName);

                _bomItemRepository.Add(bomItem);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return bomItem.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create BOM item: {ex.Message}");
            }
        }

        #endregion
    }
}
