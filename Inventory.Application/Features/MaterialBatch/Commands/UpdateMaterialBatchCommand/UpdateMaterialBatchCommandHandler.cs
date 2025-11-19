using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Commands.UpdateMaterialBatchCommand
{
    public class UpdateMaterialBatchCommandHandler
        : IRequestHandler<UpdateMaterialBatchCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMaterialBatchRepository _materialBatchRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateMaterialBatchCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IMaterialBatchRepository materialBatchRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _materialBatchRepository = materialBatchRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateMaterialBatchCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load existing material batch or fail if it doesn't exist
                var materialBatch = await _materialBatchRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No material batch found with Id '{request.Id}'.");

                //2. Check barcode uniqueness if provided
                if (!string.IsNullOrWhiteSpace(request.Barcode) &&
                    await _materialBatchRepository.ExistsByBarcodeAsync(request.Barcode, cancellationToken))
                {
                    throw new InvalidOperationException($"A material batch with barcode '{request.Barcode}' already exists.");
                }

                //3. Identify who's making the change
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
                var userName = "System";

                //4. Apply updates and persist the changes
                materialBatch.Update(
                    request.VendorId,
                    request.Barcode,
                    request.ManufactureDate,
                    request.ExpiryDate,
                    request.StorageSectionId,
                    request.LocationText,
                    userName);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update material batch: {ex.Message}");
            }
        }

        #endregion
    }
}
