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

namespace Inventory.Application.Features.Aisle.Commands.CreateAisleCommand
{
    public class CreateAisleCommandHandler
        : IRequestHandler<CreateAisleCommand, int>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAisleRepository _aisleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public CreateAisleCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IAisleRepository aisleRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _aisleRepository = aisleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<int> Handle(
            CreateAisleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Prevent duplicates
                if (await _aisleRepository.ExistsByNameAsync(request.Name, cancellationToken))
                {
                    throw new InvalidOperationException($"An aisle named '{request.Name}' already exists.");
                }

                // 2. Identify the creator
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Could not determine the current user.");
                var userName = "System";

                // 3. Create and persist the new aisle
                var aisle = AisleDO.Create(
                    request.Name,
                    request.WarehouseId,
                    request.StorageSectionId,
                    request.StorageTypeId,
                    request.InventoryTypeId,
                    userName);

                _aisleRepository.Add(aisle);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return aisle.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create aisle {ex.Message}");
            }
        }

        #endregion
    }
}
