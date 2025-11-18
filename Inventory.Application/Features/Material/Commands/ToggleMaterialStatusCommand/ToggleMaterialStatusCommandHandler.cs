using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Commands.ToggleMaterialStatusCommand
{
    public class ToggleMaterialStatusCommandHandler : IRequestHandler<ToggleMaterialStatusCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMaterialRepository _materialRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public ToggleMaterialStatusCommandHandler(
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

        public async Task<Unit> Handle(
            ToggleMaterialStatusCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the material or fail if it doesn't exist
                var material = await _materialRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No material found with Id '{request.Id}'.");

                //2. Identify who's performing the toggle
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
                var userName = "System"; // TODO: Replace with actual user identification

                if (request.IsActive)
                {
                    material.Activate(userName);
                }
                else
                {
                    material.Deactivate(userName);
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to toggle material status: {ex.Message}");
            }
        }

        #endregion
    }
}
