using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.Vendor.Commands.CreateVendorCommand
{
    public class CreateVendorCommandHandler : IRequestHandler<CreateVendorCommand, int>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVendorRepository _vendorRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateVendorCommandHandler(
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

        public async Task<int> Handle(
            CreateVendorCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Prevent duplicates
                if (await _vendorRepository.ExistsByNameAsync(request.Name, cancellationToken))
                {
                    throw new InvalidOperationException($"A vendor named '{request.Name}' already exists.");
                }

                // 2. Identify the creator
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Could not determine the current user.");
                var userName = "System"; // TODO: Replace with actual user identification

                // 3. Create and persist the new vendor
                var vendor = VendorDO.Create(
                    request.Name,
                    request.Type,
                    request.Contact,
                    userName);

                _vendorRepository.Add(vendor);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return vendor.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create vendor: {ex.Message}");
            }
        }

        #endregion
    }
}
