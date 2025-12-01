using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Commands.UpdateAllocationStatusCommand
{
    public class UpdateAllocationStatusCommandHandler : IRequestHandler<UpdateAllocationStatusCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAllocationRepository _allocationRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public UpdateAllocationStatusCommandHandler(
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
            UpdateAllocationStatusCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load existing allocation or fail if it doesn't exist
                var allocation = await _allocationRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No allocation found with Id '{request.Id}'.");

                // 2. Identify who's making the change
                var userName = "System"; // TODO: Replace with actual user identification

                // 3. Update status based on requested action
                switch (request.Status.ToLower())
                {
                    case "picked":
                        allocation.MarkAsPicked(userName);
                        break;
                    case "shipped":
                        allocation.MarkAsShipped(userName);
                        break;
                    case "released":
                        allocation.Release(userName);
                        break;
                    case "cancelled":
                        allocation.Cancel(userName);
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid status: {request.Status}. Valid statuses are: picked, shipped, released, cancelled");
                }

                // 4. Persist changes
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update allocation status: {ex.Message}");
            }
        }

        #endregion
    }
}
