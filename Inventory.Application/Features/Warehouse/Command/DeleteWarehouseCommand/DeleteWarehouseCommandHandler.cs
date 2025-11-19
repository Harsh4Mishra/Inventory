using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Command.DeleteWarehouseCommand
{
    public class DeleteWarehouseCommandHandler
        : IRequestHandler<DeleteWarehouseCommand, Unit>
    {
        #region Fields

        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteWarehouseCommandHandler(
            IWarehouseRepository warehouseRepository,
            IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteWarehouseCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the warehouse or fail if it doesn't exist
                var warehouse = await _warehouseRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No warehouse found with Id '{request.Id}'.");

                //2. Remove and persist
                _warehouseRepository.Remove(warehouse);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete warehouse: {ex.Message}");
            }
        }

        #endregion
    }
}
