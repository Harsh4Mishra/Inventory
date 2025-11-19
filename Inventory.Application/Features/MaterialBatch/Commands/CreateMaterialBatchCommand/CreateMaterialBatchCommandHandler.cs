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

namespace Inventory.Application.Features.MaterialBatch.Commands.CreateMaterialBatchCommand
{
    public class CreateMaterialBatchCommandHandler : IRequestHandler<CreateMaterialBatchCommand, Guid>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMaterialBatchRepository _materialBatchRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateMaterialBatchCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IMaterialBatchRepository materialBatchRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _materialBatchRepository = materialBatchRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Guid> Handle(
            CreateMaterialBatchCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Prevent duplicates by batch code
                if (await _materialBatchRepository.ExistsByBatchCodeAsync(request.BatchCode, cancellationToken))
                {
                    throw new InvalidOperationException($"A material batch with code '{request.BatchCode}' already exists.");
                }

                // 2. Prevent duplicates by barcode if provided
                if (!string.IsNullOrWhiteSpace(request.Barcode) &&
                    await _materialBatchRepository.ExistsByBarcodeAsync(request.Barcode, cancellationToken))
                {
                    throw new InvalidOperationException($"A material batch with barcode '{request.Barcode}' already exists.");
                }

                // 3. Validate quantity
                if (request.Quantity <= 0)
                {
                    throw new InvalidOperationException("Quantity must be greater than zero.");
                }

                // 4. Identify the creator
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Could not determine the current user.");
                var userName = "System"; // TODO: Replace with actual user identification

                // 5. Create and persist the new material batch
                var materialBatch = MaterialBatchDO.Create(
                    request.MaterialId,
                    request.VendorId,
                    request.BatchCode,
                    request.Barcode,
                    request.ManufactureDate,
                    request.ExpiryDate,
                    request.Quantity,
                    request.StorageSectionId,
                    request.LocationText,
                    userName);

                _materialBatchRepository.Add(materialBatch);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return materialBatch.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create material batch: {ex.Message}");
            }
        }

        #endregion
    }
}
