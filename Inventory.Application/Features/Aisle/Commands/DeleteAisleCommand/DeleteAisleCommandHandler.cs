using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Aisle.Commands.DeleteAisleCommand
{
    public class DeleteAisleCommandHandler
        : IRequestHandler<DeleteAisleCommand, Unit>
    {
        #region Fields

        private readonly IAisleRepository _aisleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteAisleCommandHandler(
            IAisleRepository aisleRepository,
            IUnitOfWork unitOfWork)
        {
            _aisleRepository = aisleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteAisleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the aisle or fail if it doesn't exist
                var aisle = await _aisleRepository.GetByIdAsync(request.Id, cancellationToken) ??
                    throw new InvalidOperationException($"No aisle found with Id '{request.Id}'.");

                // 2. Remove and persist
                _aisleRepository.Remove(aisle);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete aisle {ex.Message}");
            }
        }

        #endregion
    }
}
