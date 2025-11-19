using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Commands.DeleteMaterialBatchCommand
{
    public class DeleteMaterialBatchCommandHandler
        : IRequestHandler<DeleteMaterialBatchCommand, Unit>
    {
        #region Fields

        private readonly IMaterialBatchRepository _materialBatchRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteMaterialBatchCommandHandler(
            IMaterialBatchRepository materialBatchRepository,
            IUnitOfWork unitOfWork)
        {
            _materialBatchRepository = materialBatchRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteMaterialBatchCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the material batch or fail if it doesn't exist
                var materialBatch = await _materialBatchRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No material batch found with Id '{request.Id}'.");

                //2. Remove and persist
                _materialBatchRepository.Remove(materialBatch);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete material batch: {ex.Message}");
            }
        }

        #endregion
    }
}
