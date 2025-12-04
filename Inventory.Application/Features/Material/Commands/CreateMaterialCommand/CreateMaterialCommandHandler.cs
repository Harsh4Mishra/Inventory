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

namespace Inventory.Application.Features.Material.Commands.CreateMaterialCommand
{
    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, int>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMaterialRepository _materialRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateMaterialCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IMaterialRepository materialRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _materialRepository = materialRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<int> Handle(
            CreateMaterialCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Prevent duplicates by SKU
                if (await _materialRepository.ExistsBySkuAsync(request.Sku, cancellationToken))
                {
                    throw new InvalidOperationException($"A material with SKU '{request.Sku}' already exists.");
                }

                // 2. Identify the creator
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Could not determine the current user.");
                var userName = "System"; // TODO: Replace with actual user identification

                // 3. Create and persist the new material
                var material = MaterialDO.Create(
                    request.Sku,
                    request.Name,
                    request.Category,
                    request.Subcategory,
                    request.CasNumber,
                    request.Description,
                    userName);

                _materialRepository.Add(material);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return material.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create material: {ex.Message}");
            }
        }

        #endregion
    }
}
