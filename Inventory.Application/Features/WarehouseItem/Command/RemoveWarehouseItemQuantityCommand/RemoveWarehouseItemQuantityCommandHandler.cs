using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.RemoveWarehouseItemQuantityCommand
{
    public class RemoveWarehouseItemQuantityCommandHandler : IRequestHandler<RemoveWarehouseItemQuantityCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWarehouseItemRepository _warehouseItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public RemoveWarehouseItemQuantityCommandHandler(
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

        public async Task<Unit> Handle(
            RemoveWarehouseItemQuantityCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the warehouse item or fail if it doesn't exist
                var warehouseItem = await _warehouseItemRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No warehouse item found with Id '{request.Id}'.");

                // 2. Identify who's making the change
                var userName = "System"; // TODO: Replace with actual user identification

                // 3. Remove quantity and persist
                warehouseItem.RemoveQuantity(request.QuantityToRemove, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Failed to remove warehouse item quantity: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to remove warehouse item quantity: {ex.Message}");
            }
        }

        #endregion
    }
}
