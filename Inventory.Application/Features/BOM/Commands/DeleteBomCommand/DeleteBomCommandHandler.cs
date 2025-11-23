using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Commands.DeleteBomCommand
{
    public class DeleteBomCommandHandler : IRequestHandler<DeleteBomCommand, Unit>
    {
        #region Fields

        private readonly IBomRepository _bomRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteBomCommandHandler(
            IBomRepository bomRepository,
            IUnitOfWork unitOfWork)
        {
            _bomRepository = bomRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteBomCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the BOM or fail if it doesn't exist
                var bom = await _bomRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No BOM found with Id '{request.Id}'.");

                // 2. Check if BOM is approved (business rule - cannot delete approved BOMs)
                if (bom.IsApproved)
                {
                    throw new InvalidOperationException($"Cannot delete approved BOM '{bom.Name}'. Please reject it first.");
                }

                // 3. Remove and persist
                _bomRepository.Remove(bom);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete BOM: {ex.Message}");
            }
        }

        #endregion
    }
}
