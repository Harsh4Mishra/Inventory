using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Commands.ToggleMaterialBatchStatusCommand
{
    public class ToggleMaterialBatchStatusCommandHandler : IRequestHandler<ToggleMaterialBatchStatusCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMaterialBatchRepository _materialBatchRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public ToggleMaterialBatchStatusCommandHandler(
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

        public async Task<Unit> Handle(
            ToggleMaterialBatchStatusCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the material batch or fail if it doesn't exist
                var materialBatch = await _materialBatchRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No material batch found with Id '{request.Id}'.");

                //2. Identify who's performing the toggle
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
                var userName = "System"; // TODO: Replace with actual user identification

                if (request.IsActive)
                {
                    materialBatch.Activate(userName);
                }
                else
                {
                    materialBatch.Deactivate(userName);
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to toggle material batch status: {ex.Message}");
            }
        }

        #endregion
    }
}
