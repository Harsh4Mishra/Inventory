using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.UpdateWarehouseItemLocationCommand
{
    public class UpdateWarehouseItemLocationCommandHandler : IRequestHandler<UpdateWarehouseItemLocationCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWarehouseItemRepository _warehouseItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public UpdateWarehouseItemLocationCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IWarehouseItemRepository warehouseItemRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _warehouseItemRepository = warehouseItemRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            UpdateWarehouseItemLocationCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the warehouse item or fail if it doesn't exist
                var warehouseItem = await _warehouseItemRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No warehouse item found with Id '{request.Id}'.");

                // 2. Check if new location is available
                if (await _warehouseItemRepository.ExistsAtLocationAsync(
                    request.WarehouseId,
                    request.AisleId,
                    request.RowId,
                    request.TrayId,
                    cancellationToken))
                {
                    throw new InvalidOperationException($"Target location is already occupied.");
                }

                // 3. Identify who's making the change
                var userName = "System"; // TODO: Replace with actual user identification

                // 4. Update location and persist
                warehouseItem.UpdateLocation(
                    request.WarehouseId,
                    request.AisleId,
                    request.RowId,
                    request.TrayId,
                    userName);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update warehouse item location: {ex.Message}");
            }
        }

        #endregion
    }
}
