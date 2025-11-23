using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Commands.UpdateBomItemQuantityCommand
{
    public class UpdateBomItemQuantityCommandHandler : IRequestHandler<UpdateBomItemQuantityCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBomItemRepository _bomItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateBomItemQuantityCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IBomItemRepository bomItemRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _bomItemRepository = bomItemRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateBomItemQuantityCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load existing BOM item or fail if it doesn't exist
                var bomItem = await _bomItemRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No BOM item found with Id '{request.Id}'.");

                // 2. Validate quantity
                if (request.Quantity <= 0)
                {
                    throw new InvalidOperationException("Quantity must be greater than zero.");
                }

                // 3. Identify who's making the change
                var userName = "System";

                // 4. Apply updates and persist the changes
                bomItem.UpdateQuantity(request.Quantity, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update BOM item quantity: {ex.Message}");
            }
        }

        #endregion
    }
}
