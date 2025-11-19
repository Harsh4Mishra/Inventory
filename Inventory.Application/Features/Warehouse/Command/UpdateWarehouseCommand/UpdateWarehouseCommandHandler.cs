using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Command.UpdateWarehouseCommand
{
    public class UpdateWarehouseCommandHandler
        : IRequestHandler<UpdateWarehouseCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateWarehouseCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IWarehouseRepository warehouseRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateWarehouseCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load existing warehouse or fail if it doesn't exist
                var warehouse = await _warehouseRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No warehouse found with Id '{request.Id}'.");

                //2. Identify who's making the change
                var userName = "System";

                //3. Apply updates and persist the changes
                warehouse.Update(request.Name, request.Address, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update warehouse: {ex.Message}");
            }
        }

        #endregion
    }
}
