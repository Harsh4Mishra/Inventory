using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Command.CreateWarehouseCommand
{
    public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, Guid>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateWarehouseCommandHandler(
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

        public async Task<Guid> Handle(
            CreateWarehouseCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Prevent duplicates
                if (await _warehouseRepository.ExistsByNameAsync(request.Name, cancellationToken))
                {
                    throw new InvalidOperationException($"A warehouse named '{request.Name}' already exists.");
                }

                // 2. Identify the creator
                var userName = "System"; // TODO: Replace with actual user identification

                // 3. Create and persist the new warehouse
                var warehouse = WarehouseDO.Create(
                    request.Name,
                    request.Address,
                    userName);

                _warehouseRepository.Add(warehouse);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return warehouse.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create warehouse: {ex.Message}");
            }
        }

        #endregion
    }
}
