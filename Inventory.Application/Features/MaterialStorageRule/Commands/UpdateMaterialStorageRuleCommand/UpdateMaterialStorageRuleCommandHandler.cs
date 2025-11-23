using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Commands.UpdateMaterialStorageRuleCommand
{
    public class UpdateMaterialStorageRuleCommandHandler : IRequestHandler<UpdateMaterialStorageRuleCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMaterialStorageRuleRepository _materialStorageRuleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateMaterialStorageRuleCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IMaterialStorageRuleRepository materialStorageRuleRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _materialStorageRuleRepository = materialStorageRuleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateMaterialStorageRuleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load existing storage rule or fail if it doesn't exist
                var rule = await _materialStorageRuleRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No material storage rule found with Id '{request.Id}'.");

                // 2. Validate quantities
                if (request.MinQuantity < 0)
                    throw new InvalidOperationException("Minimum quantity cannot be negative.");

                if (request.ThresholdQuantity < 0)
                    throw new InvalidOperationException("Threshold quantity cannot be negative.");

                if (request.ThresholdQuantity < request.MinQuantity)
                    throw new InvalidOperationException("Threshold quantity cannot be less than minimum quantity.");

                // 3. Identify who's making the change
                var userName = "System";

                // 4. Apply updates and persist the changes
                rule.UpdateAll(
                    request.MinQuantity,
                    request.ThresholdQuantity,
                    request.PreferredSectionId,
                    userName);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update material storage rule: {ex.Message}");
            }
        }

        #endregion
    }
}
