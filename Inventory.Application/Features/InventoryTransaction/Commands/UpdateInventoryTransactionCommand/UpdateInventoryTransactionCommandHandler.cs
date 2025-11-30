using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Commands.UpdateInventoryTransactionCommand
{
    public class UpdateInventoryTransactionCommandHandler : IRequestHandler<UpdateInventoryTransactionCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public UpdateInventoryTransactionCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IInventoryTransactionRepository inventoryTransactionRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _inventoryTransactionRepository = inventoryTransactionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            UpdateInventoryTransactionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load existing transaction or fail if it doesn't exist
                var transaction = await _inventoryTransactionRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No inventory transaction found with Id '{request.Id}'.");

                // 2. Identify who's making the change
                var userName = "System"; // TODO: Replace with actual user identification

                // 3. Apply updates
                if (request.Cost.HasValue)
                {
                    transaction.UpdateCost(request.Cost.Value, userName);
                }

                if (request.Notes != null)
                {
                    transaction.UpdateNotes(request.Notes, userName);
                }

                // 4. Persist changes
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update inventory transaction: {ex.Message}");
            }
        }

        #endregion
    }
}
