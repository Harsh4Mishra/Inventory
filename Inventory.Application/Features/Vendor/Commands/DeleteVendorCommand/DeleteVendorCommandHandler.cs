using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Commands.DeleteVendorCommand
{
    public class DeleteVendorCommandHandler
        : IRequestHandler<DeleteVendorCommand, Unit>
    {
        #region Fields

        private readonly IVendorRepository _vendorRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteVendorCommandHandler(
            IVendorRepository vendorRepository,
            IUnitOfWork unitOfWork)
        {
            _vendorRepository = vendorRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteVendorCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the vendor or fail if it doesn't exist
                var vendor = await _vendorRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No vendor found with Id '{request.Id}'.");

                //2. Remove and persist
                _vendorRepository.Remove(vendor);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete vendor: {ex.Message}");
            }
        }

        #endregion
    }
}
