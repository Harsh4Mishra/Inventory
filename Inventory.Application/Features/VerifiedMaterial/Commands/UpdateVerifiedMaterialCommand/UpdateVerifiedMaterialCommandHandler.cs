using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.UpdateVerifiedMaterialCommand
{
    public class UpdateVerifiedMaterialCommandHandler
        : IRequestHandler<UpdateVerifiedMaterialCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVerifiedMaterialRepository _verifiedMaterialRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateVerifiedMaterialCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IVerifiedMaterialRepository verifiedMaterialRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _verifiedMaterialRepository = verifiedMaterialRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateVerifiedMaterialCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load existing verified material or fail if it doesn't exist
                var verifiedMaterial = await _verifiedMaterialRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No verified material found with Id '{request.Id}'.");

                //2. Identify who's making the change
                var userName = "System";

                //3. Apply updates and persist the changes
                verifiedMaterial.UpdateVerification(
                    request.IsQualified,
                    request.Reason,
                    request.EmpId,
                    request.Specification,
                    userName);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update verified material: {ex.Message}");
            }
        }

        #endregion
    }
}
