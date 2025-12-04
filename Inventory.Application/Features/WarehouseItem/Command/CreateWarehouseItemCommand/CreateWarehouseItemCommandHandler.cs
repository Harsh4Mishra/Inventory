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

namespace Inventory.Application.Features.WarehouseItem.Command.CreateWarehouseItemCommand
{
    public class CreateWarehouseItemCommandHandler : IRequestHandler<CreateWarehouseItemCommand, int>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWarehouseItemRepository _warehouseItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateWarehouseItemCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IWarehouseItemRepository warehouseItemRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _warehouseItemRepository = warehouseItemRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<int> Handle(
            CreateWarehouseItemCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Check if item already exists at this location
                if (await _warehouseItemRepository.ExistsAtLocationAsync(
                    request.WarehouseId,
                    request.AisleId,
                    request.RowId,
                    request.TrayId,
                    cancellationToken))
                {
                    throw new InvalidOperationException($"An item already exists at the specified location.");
                }

                // 2. Check if material batch already exists in warehouse
                if (await _warehouseItemRepository.ExistsByMaterialBatchIdAsync(request.MaterialBatchId, cancellationToken))
                {
                    throw new InvalidOperationException($"Material batch '{request.MaterialBatchId}' already exists in warehouse.");
                }

                // 3. Identify the creator
                var userName = "System"; // TODO: Replace with actual user identification

                // 4. Create and persist the new warehouse item
                var warehouseItem = WarehouseItemDO.Create(
                    request.MaterialBatchId,
                    request.WarehouseId,
                    request.AisleId,
                    request.RowId,
                    request.TrayId,
                    request.Quantity,
                    request.Name,
                    request.Specification,
                    userName);

                _warehouseItemRepository.Add(warehouseItem);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return warehouseItem.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create warehouse item: {ex.Message}");
            }
        }

        #endregion
    }
}
