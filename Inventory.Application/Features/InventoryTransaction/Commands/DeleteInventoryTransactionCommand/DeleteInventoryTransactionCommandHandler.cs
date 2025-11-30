using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Commands.DeleteInventoryTransactionCommand
{
    public class DeleteInventoryTransactionCommandHandler : IRequestHandler<DeleteInventoryTransactionCommand, Unit>
    {
        #region Fields

        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public DeleteInventoryTransactionCommandHandler(
            IInventoryTransactionRepository inventoryTransactionRepository,
            IUnitOfWork unitOfWork)
        {
            _inventoryTransactionRepository = inventoryTransactionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            DeleteInventoryTransactionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the transaction or fail if it doesn't exist
                var transaction = await _inventoryTransactionRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No inventory transaction found with Id '{request.Id}'.");

                // 2. Remove and persist
                _inventoryTransactionRepository.Remove(transaction);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete inventory transaction: {ex.Message}");
            }
        }

        #endregion
    }
}
