using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Commands.UpdateVendorCommand
{
    public class UpdateVendorCommandHandler
        : IRequestHandler<UpdateVendorCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVendorRepository _vendorRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateVendorCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IVendorRepository vendorRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _vendorRepository = vendorRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateVendorCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load existing vendor or fail if it doesn't exist
                var vendor = await _vendorRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No vendor found with Id '{request.Id}'.");

                //2. Identify who's making the change
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
                var userName = "System";

                //3. Apply updates and persist the changes
                vendor.Update(request.Name, request.Type, request.Contact, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update vendor: {ex.Message}");
            }
        }

        #endregion
    }
}
