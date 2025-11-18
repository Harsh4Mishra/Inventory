using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Commands.ToggleVendorStatusCommand
{
    public class ToggleVendorStatusCommandHandler : IRequestHandler<ToggleVendorStatusCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVendorRepository _vendorRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public ToggleVendorStatusCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IVendorRepository vendorRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _vendorRepository = vendorRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            ToggleVendorStatusCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the vendor or fail if it doesn't exist
                var vendor = await _vendorRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No vendor found with Id '{request.Id}'.");

                //2. Identify who's performing the toggle
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
                var userName = "System"; // TODO: Replace with actual user identification

                if (request.IsActive)
                {
                    vendor.Activate(userName);
                }
                else
                {
                    vendor.Deactivate(userName);
                }

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to toggle vendor status: {ex.Message}");
            }
        }

        #endregion
    }
}
