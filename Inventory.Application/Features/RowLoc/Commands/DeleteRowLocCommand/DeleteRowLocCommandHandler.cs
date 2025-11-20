using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Commands.DeleteRowLocCommand
{
    public sealed class DeleteRowLocCommandHandler
        : IRequestHandler<DeleteRowLocCommand, Unit>
    {
        #region Fields

        private readonly IAisleRepository _aisleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteRowLocCommandHandler(
            IAisleRepository aisleRepository,
            IUnitOfWork unitOfWork)
        {
            _aisleRepository = aisleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(DeleteRowLocCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the aisle or fail if it doesn't exist
                var aisle = await _aisleRepository.GetByIdToMutateAsync(request.AisleId, cancellationToken) ??
                    throw new InvalidOperationException($"No aisle found with Id '{request.AisleId}'.");

                // 2. Delete and persist
                aisle.DeleteRowLoc(request.Id);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
