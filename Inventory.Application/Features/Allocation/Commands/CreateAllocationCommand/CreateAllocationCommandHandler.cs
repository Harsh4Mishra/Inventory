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

namespace Inventory.Application.Features.Allocation.Commands.CreateAllocationCommand
{
    public class CreateAllocationCommandHandler : IRequestHandler<CreateAllocationCommand, int>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAllocationRepository _allocationRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateAllocationCommandHandler(
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

        public async Task<int> Handle(
            CreateAllocationCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Check for duplicate allocation
                var existingAllocation = await _allocationRepository.GetActiveAllocationsAsync(cancellationToken);
                if (existingAllocation.Any(a => a.OrderId == request.OrderId &&
                                                a.ProductId == request.ProductId &&
                                                a.MaterialBatchId == request.MaterialBatchId))
                {
                    throw new InvalidOperationException($"Allocation already exists for this order, product, and material batch combination.");
                }

                // 2. Identify the creator
                var userName = "System"; // TODO: Replace with actual user identification

                // 3. Create and persist the new allocation
                var allocation = AllocationDO.Create(
                    request.OrderId,
                    request.ProductId,
                    request.MaterialBatchId,
                    request.Quantity,
                    userName);

                _allocationRepository.Add(allocation);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return allocation.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create allocation: {ex.Message}");
            }
        }

        #endregion
    }
}
