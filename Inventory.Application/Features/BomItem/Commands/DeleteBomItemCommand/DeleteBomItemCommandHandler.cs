using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItem.Commands.DeleteBomItemCommand
{
    public class DeleteBomItemCommandHandler : IRequestHandler<DeleteBomItemCommand, Unit>
    {
        #region Fields

        private readonly IBomItemRepository _bomItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteBomItemCommandHandler(
            IBomItemRepository bomItemRepository,
            IUnitOfWork unitOfWork)
        {
            _bomItemRepository = bomItemRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteBomItemCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the BOM item or fail if it doesn't exist
                var bomItem = await _bomItemRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No BOM item found with Id '{request.Id}'.");

                // 2. Remove and persist
                _bomItemRepository.Remove(bomItem);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete BOM item: {ex.Message}");
            }
        }

        #endregion
    }
}
