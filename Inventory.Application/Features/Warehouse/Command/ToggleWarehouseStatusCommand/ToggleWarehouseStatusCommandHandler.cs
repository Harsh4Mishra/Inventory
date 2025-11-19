using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Command.ToggleWarehouseStatusCommand
{
    public class ToggleWarehouseStatusCommandHandler : IRequestHandler<ToggleWarehouseStatusCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public ToggleWarehouseStatusCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IWarehouseRepository warehouseRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            ToggleWarehouseStatusCommand request,
            CancellationToken cancellationToken)
        {
            //1. Load the warehouse or fail if it doesn't exist
            var warehouse = await _warehouseRepository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new InvalidOperationException($"No warehouse found with Id '{request.Id}'.");

            //2. Identify who's performing the toggle
            var userName = "System"; // TODO: Replace with actual user identification

            if (request.IsActive)
            {
                warehouse.Activate(userName);
            }
            else
            {
                warehouse.Deactivate(userName);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        #endregion
    }
}
