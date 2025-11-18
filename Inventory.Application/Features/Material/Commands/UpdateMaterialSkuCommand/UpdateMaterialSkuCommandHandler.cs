using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Commands.UpdateMaterialSkuCommand
{
    public class UpdateMaterialSkuCommandHandler
        : IRequestHandler<UpdateMaterialSkuCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMaterialRepository _materialRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateMaterialSkuCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IMaterialRepository materialRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _materialRepository = materialRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateMaterialSkuCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load existing material or fail if it doesn't exist
                var material = await _materialRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No material found with Id '{request.Id}'.");

                //2. Check if new SKU already exists
                if (await _materialRepository.ExistsBySkuAsync(request.Sku, cancellationToken))
                {
                    throw new InvalidOperationException($"A material with SKU '{request.Sku}' already exists.");
                }

                //3. Identify who's making the change
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
                var userName = "System";

                //4. Apply SKU update and persist the changes
                material.UpdateSku(request.Sku, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update material SKU: {ex.Message}");
            }
        }

        #endregion
    }
}
