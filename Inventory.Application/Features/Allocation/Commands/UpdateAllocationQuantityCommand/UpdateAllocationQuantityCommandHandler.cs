using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Commands.UpdateAllocationQuantityCommand
{
    public class UpdateAllocationQuantityCommandHandler : IRequestHandler<UpdateAllocationQuantityCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAllocationRepository _allocationRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public UpdateAllocationQuantityCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IAllocationRepository allocationRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _allocationRepository = allocationRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            UpdateAllocationQuantityCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load existing allocation or fail if it doesn't exist
                var allocation = await _allocationRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No allocation found with Id '{request.Id}'.");

                // 2. Identify who's making the change
                var userName = "System"; // TODO: Replace with actual user identification

                // 3. Update quantity
                allocation.UpdateQuantity(request.Quantity, userName);

                // 4. Persist changes
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update allocation quantity: {ex.Message}");
            }
        }

        #endregion
    }
}
