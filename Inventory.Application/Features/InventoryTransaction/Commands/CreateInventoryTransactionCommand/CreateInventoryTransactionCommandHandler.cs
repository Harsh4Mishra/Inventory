using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Commands.CreateInventoryTransactionCommand
{
    public class CreateInventoryTransactionCommandHandler : IRequestHandler<CreateInventoryTransactionCommand, int>
    {
        #region Fields

        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateInventoryTransactionCommandHandler(
            IInventoryTransactionRepository inventoryTransactionRepository,
            IUnitOfWork unitOfWork)
        {
            _inventoryTransactionRepository = inventoryTransactionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<int> Handle(
            CreateInventoryTransactionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Validate transaction type
                ValidateTransactionType(request.TransactionType);

                // 2. Validate location constraints based on transaction type
                ValidateLocationConstraints(request);

                // 3. Create the transaction based on type
                InventoryTransactionDO transaction = request.TransactionType.ToLower() switch
                {
                    "receive" => InventoryTransactionDO.CreateReceive(
                        request.Quantity,
                        request.CreatedBy,
                        request.ToWarehouseId ?? throw new InvalidOperationException("ToWarehouseId is required for receive transactions"),
                        request.MaterialBatchId,
                        request.ProductId,
                        request.ToAisleId,
                        request.ToRowId,
                        request.ToTrayId,
                        request.ReferenceType,
                        request.ReferenceId,
                        request.Cost,
                        request.Notes),

                    "issue" => InventoryTransactionDO.CreateIssue(
                        request.Quantity,
                        request.CreatedBy,
                        request.FromWarehouseId ?? throw new InvalidOperationException("FromWarehouseId is required for issue transactions"),
                        request.MaterialBatchId,
                        request.ProductId,
                        request.FromAisleId,
                        request.FromRowId,
                        request.FromTrayId,
                        request.ReferenceType,
                        request.ReferenceId,
                        request.Cost,
                        request.Notes),

                    "transfer" => InventoryTransactionDO.CreateTransfer(
                        request.Quantity,
                        request.CreatedBy,
                        request.FromWarehouseId ?? throw new InvalidOperationException("FromWarehouseId is required for transfer transactions"),
                        request.ToWarehouseId ?? throw new InvalidOperationException("ToWarehouseId is required for transfer transactions"),
                        request.MaterialBatchId,
                        request.ProductId,
                        request.FromAisleId,
                        request.ToAisleId,
                        request.FromRowId,
                        request.ToRowId,
                        request.FromTrayId,
                        request.ToTrayId,
                        request.ReferenceType,
                        request.ReferenceId,
                        request.Cost,
                        request.Notes),

                    "adjust" => InventoryTransactionDO.CreateAdjustment(
                        request.Quantity,
                        request.CreatedBy,
                        request.FromWarehouseId ?? request.ToWarehouseId,
                        request.MaterialBatchId,
                        request.ProductId,
                        request.FromAisleId ?? request.ToAisleId,
                        request.FromRowId ?? request.ToRowId,
                        request.FromTrayId ?? request.ToTrayId,
                        request.ReferenceType,
                        request.ReferenceId,
                        request.Cost,
                        request.Notes),

                    _ => throw new InvalidOperationException($"Unsupported transaction type: {request.TransactionType}")
                };

                // 4. Add and persist the transaction
                _inventoryTransactionRepository.Add(transaction);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return transaction.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create inventory transaction: {ex.Message}");
            }
        }

        #endregion

        #region Private Methods

        private void ValidateTransactionType(string transactionType)
        {
            var validTypes = new[] { "receive", "issue", "transfer", "adjust", "allocate", "deallocate" };
            if (!validTypes.Contains(transactionType.ToLower()))
            {
                throw new InvalidOperationException($"Invalid transaction type: {transactionType}. Valid types are: {string.Join(", ", validTypes)}");
            }
        }

        private void ValidateLocationConstraints(CreateInventoryTransactionCommand request)
        {
            switch (request.TransactionType.ToLower())
            {
                case "receive":
                    if (request.FromWarehouseId != null)
                        throw new InvalidOperationException("FromWarehouseId should not be provided for receive transactions");
                    break;

                case "issue":
                    if (request.ToWarehouseId != null)
                        throw new InvalidOperationException("ToWarehouseId should not be provided for issue transactions");
                    break;

                case "transfer":
                    if (request.FromWarehouseId == null || request.ToWarehouseId == null)
                        throw new InvalidOperationException("Both FromWarehouseId and ToWarehouseId are required for transfer transactions");
                    if (request.FromWarehouseId == request.ToWarehouseId)
                        throw new InvalidOperationException("FromWarehouseId and ToWarehouseId cannot be the same for transfer transactions");
                    break;

                case "adjust":
                    if (request.FromWarehouseId == null && request.ToWarehouseId == null)
                        throw new InvalidOperationException("Either FromWarehouseId or ToWarehouseId must be provided for adjustment transactions");
                    break;
            }
        }

        #endregion
    }
}
