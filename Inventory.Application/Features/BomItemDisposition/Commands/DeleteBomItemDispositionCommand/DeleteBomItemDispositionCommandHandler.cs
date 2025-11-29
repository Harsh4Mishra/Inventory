using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Commands.DeleteBomItemDispositionCommand
{
    public class DeleteBomItemDispositionCommandHandler
        : IRequestHandler<DeleteBomItemDispositionCommand, Unit>
    {
        #region Fields

        private readonly IBomItemDispositionRepository _bomItemDispositionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteBomItemDispositionCommandHandler(
            IBomItemDispositionRepository bomItemDispositionRepository,
            IUnitOfWork unitOfWork)
        {
            _bomItemDispositionRepository = bomItemDispositionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteBomItemDispositionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the disposition or fail if it doesn't exist
                var disposition = await _bomItemDispositionRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No BOM item disposition found with Id '{request.Id}'.");

                //2. Remove and persist
                _bomItemDispositionRepository.Remove(disposition);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete BOM item disposition: {ex.Message}");
            }
        }

        #endregion
    }
}
