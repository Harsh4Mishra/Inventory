using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.DeleteVerifiedMaterialCommand
{
    public class DeleteVerifiedMaterialCommandHandler
        : IRequestHandler<DeleteVerifiedMaterialCommand, Unit>
    {
        #region Fields

        private readonly IVerifiedMaterialRepository _verifiedMaterialRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteVerifiedMaterialCommandHandler(
            IVerifiedMaterialRepository verifiedMaterialRepository,
            IUnitOfWork unitOfWork)
        {
            _verifiedMaterialRepository = verifiedMaterialRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteVerifiedMaterialCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the verified material or fail if it doesn't exist
                var verifiedMaterial = await _verifiedMaterialRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No verified material found with Id '{request.Id}'.");

                //2. Check business rules before deletion (e.g., cannot delete allotted material)
                if (verifiedMaterial.IsAllotted)
                {
                    throw new InvalidOperationException("Cannot delete allotted verified material.");
                }

                //3. Remove and persist
                _verifiedMaterialRepository.Remove(verifiedMaterial);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete verified material: {ex.Message}");
            }
        }

        #endregion
    }
}
