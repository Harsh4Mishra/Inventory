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

namespace Inventory.Application.Features.VerifiedMaterial.Commands.CreateVerifiedMaterialCommand
{
    public class CreateVerifiedMaterialCommandHandler : IRequestHandler<CreateVerifiedMaterialCommand, int>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVerifiedMaterialRepository _verifiedMaterialRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateVerifiedMaterialCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IVerifiedMaterialRepository verifiedMaterialRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _verifiedMaterialRepository = verifiedMaterialRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<int> Handle(
            CreateVerifiedMaterialCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Validate business rules
                if (request.Quantity <= 0)
                {
                    throw new InvalidOperationException("Quantity must be greater than zero.");
                }

                // 2. Check if material batch already has verified material (optional business rule)
                var existingVerifiedMaterials = await _verifiedMaterialRepository
                    .GetByMaterialBatchIdAsync(request.MaterialBatchId, cancellationToken);

                // Add any additional business rule validations here

                // 3. Identify the creator
                var userName = "System"; // TODO: Replace with actual user identification

                // 4. Create and persist the new verified material
                var verifiedMaterial = VerifiedMaterialDO.Create(
                    request.MaterialBatchId,
                    request.Quantity,
                    request.EmpId,
                    request.Specification,
                    request.IsQualified,
                    request.Reason,
                    userName);

                _verifiedMaterialRepository.Add(verifiedMaterial);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return verifiedMaterial.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create verified material: {ex.Message}");
            }
        }

        #endregion
    }
}
