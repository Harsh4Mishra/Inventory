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

namespace Inventory.Application.Features.MaterialStorageRule.Commands.CreateMaterialStorageRuleCommand
{
    public class CreateMaterialStorageRuleCommandHandler : IRequestHandler<CreateMaterialStorageRuleCommand, int>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMaterialStorageRuleRepository _materialStorageRuleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateMaterialStorageRuleCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IMaterialStorageRuleRepository materialStorageRuleRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _materialStorageRuleRepository = materialStorageRuleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<int> Handle(
            CreateMaterialStorageRuleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Prevent duplicates (one rule per material)
                if (await _materialStorageRuleRepository.ExistsByMaterialIdAsync(request.MaterialId, cancellationToken))
                {
                    throw new InvalidOperationException($"A storage rule already exists for material '{request.MaterialId}'.");
                }

                // 2. Validate quantities
                if (request.MinQuantity < 0)
                    throw new InvalidOperationException("Minimum quantity cannot be negative.");

                if (request.ThresholdQuantity < 0)
                    throw new InvalidOperationException("Threshold quantity cannot be negative.");

                if (request.ThresholdQuantity < request.MinQuantity)
                    throw new InvalidOperationException("Threshold quantity cannot be less than minimum quantity.");

                // 3. Identify the creator
                var userName = "System"; // TODO: Replace with actual user identification

                // 4. Create and persist the new storage rule
                var rule = MaterialStorageRuleDO.Create(
                    request.MaterialId,
                    request.MinQuantity,
                    request.ThresholdQuantity,
                    request.PreferredSectionId,
                    userName);

                _materialStorageRuleRepository.Add(rule);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return rule.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create material storage rule: {ex.Message}");
            }
        }

        #endregion
    }
}
