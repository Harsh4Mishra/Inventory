using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Commands.UpdateMaterialBatchQuantityCommand
{
    public class UpdateMaterialBatchQuantityCommandHandler
        : IRequestHandler<UpdateMaterialBatchQuantityCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMaterialBatchRepository _materialBatchRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateMaterialBatchQuantityCommandHandler(
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
            UpdateMaterialBatchQuantityCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load existing material batch or fail if it doesn't exist
                var materialBatch = await _materialBatchRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No material batch found with Id '{request.Id}'.");

                //2. Identify who's making the change
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
                var userName = "System";

                //3. Apply quantity update
                materialBatch.UpdateQuantity(request.NewQuantity, userName);

                //4. Persist the changes
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update material batch quantity: {ex.Message}");
            }
        }

        #endregion
    }
}
