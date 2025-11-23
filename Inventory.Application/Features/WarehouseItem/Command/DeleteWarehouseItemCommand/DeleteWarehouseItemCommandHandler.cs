using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.DeleteWarehouseItemCommand
{
    public class DeleteWarehouseItemCommandHandler : IRequestHandler<DeleteWarehouseItemCommand, Unit>
    {
        #region Fields

        private readonly IWarehouseItemRepository _warehouseItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteWarehouseItemCommandHandler(
            IWarehouseItemRepository warehouseItemRepository,
            IUnitOfWork unitOfWork)
        {
            _warehouseItemRepository = warehouseItemRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteWarehouseItemCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the warehouse item or fail if it doesn't exist
                var warehouseItem = await _warehouseItemRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No warehouse item found with Id '{request.Id}'.");

                // 2. Check if item has quantity before deletion (business rule)
                if (warehouseItem.Quantity > 0)
                {
                    throw new InvalidOperationException($"Cannot delete warehouse item with remaining quantity. Current quantity: {warehouseItem.Quantity}");
                }

                // 3. Remove and persist
                _warehouseItemRepository.Remove(warehouseItem);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete warehouse item: {ex.Message}");
            }
        }

        #endregion
    }
}
