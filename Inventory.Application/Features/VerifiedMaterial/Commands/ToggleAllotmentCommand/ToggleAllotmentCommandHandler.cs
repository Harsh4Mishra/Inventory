using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.ToggleAllotmentCommand
{
    public class ToggleAllotmentCommandHandler : IRequestHandler<ToggleAllotmentCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVerifiedMaterialRepository _verifiedMaterialRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public ToggleAllotmentCommandHandler(
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
            ToggleAllotmentCommand request,
            CancellationToken cancellationToken)
        {
            //1. Load the verified material or fail if it doesn't exist
            var verifiedMaterial = await _verifiedMaterialRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                ?? throw new InvalidOperationException($"No verified material found with Id '{request.Id}'.");

            //2. Identify who's performing the toggle
            var userName = "System"; // TODO: Replace with actual user identification

            if (request.IsAllotted)
            {
                verifiedMaterial.Allot(userName);
            }
            else
            {
                verifiedMaterial.ReleaseAllotment(userName);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        #endregion
    }
}
