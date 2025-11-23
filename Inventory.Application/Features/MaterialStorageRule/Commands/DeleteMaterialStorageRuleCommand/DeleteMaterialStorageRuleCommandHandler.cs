using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialStorageRule.Commands.DeleteMaterialStorageRuleCommand
{
    public class DeleteMaterialStorageRuleCommandHandler : IRequestHandler<DeleteMaterialStorageRuleCommand, Unit>
    {
        #region Fields

        private readonly IMaterialStorageRuleRepository _materialStorageRuleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteMaterialStorageRuleCommandHandler(
            IMaterialStorageRuleRepository materialStorageRuleRepository,
            IUnitOfWork unitOfWork)
        {
            _materialStorageRuleRepository = materialStorageRuleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteMaterialStorageRuleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the storage rule or fail if it doesn't exist
                var rule = await _materialStorageRuleRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No material storage rule found with Id '{request.Id}'.");

                // 2. Remove and persist
                _materialStorageRuleRepository.Remove(rule);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete material storage rule: {ex.Message}");
            }
        }

        #endregion
    }
}
