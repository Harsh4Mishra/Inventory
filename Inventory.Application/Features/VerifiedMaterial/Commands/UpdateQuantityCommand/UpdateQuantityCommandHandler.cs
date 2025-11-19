using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.UpdateQuantityCommand
{
    public class UpdateQuantityCommandHandler : IRequestHandler<UpdateQuantityCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVerifiedMaterialRepository _verifiedMaterialRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public UpdateQuantityCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IVerifiedMaterialRepository verifiedMaterialRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _verifiedMaterialRepository = verifiedMaterialRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            UpdateQuantityCommand request,
            CancellationToken cancellationToken)
        {
            //1. Load the verified material or fail if it doesn't exist
            var verifiedMaterial = await _verifiedMaterialRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                ?? throw new InvalidOperationException($"No verified material found with Id '{request.Id}'.");

            //2. Identify who's performing the update
            var userName = "System"; // TODO: Replace with actual user identification

            //3. Update quantity
            verifiedMaterial.UpdateQuantity(request.Quantity, userName);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        #endregion
    }
}
