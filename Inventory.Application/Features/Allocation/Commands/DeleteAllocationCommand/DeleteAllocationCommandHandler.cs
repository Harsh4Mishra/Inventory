using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Commands.DeleteAllocationCommand
{
    public class DeleteAllocationCommandHandler : IRequestHandler<DeleteAllocationCommand, Unit>
    {
        #region Fields

        private readonly IAllocationRepository _allocationRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public DeleteAllocationCommandHandler(
            IAllocationRepository allocationRepository,
            IUnitOfWork unitOfWork)
        {
            _allocationRepository = allocationRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            DeleteAllocationCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the allocation or fail if it doesn't exist
                var allocation = await _allocationRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No allocation found with Id '{request.Id}'.");

                // 2. Remove and persist
                _allocationRepository.Remove(allocation);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete allocation: {ex.Message}");
            }
        }

        #endregion
    }

}
