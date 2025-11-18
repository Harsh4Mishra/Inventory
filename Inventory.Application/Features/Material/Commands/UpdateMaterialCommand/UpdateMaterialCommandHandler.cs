using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Commands.UpdateMaterialCommand
{
    public class UpdateMaterialCommandHandler
        : IRequestHandler<UpdateMaterialCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMaterialRepository _materialRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateMaterialCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IMaterialRepository materialRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _materialRepository = materialRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateMaterialCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load existing material or fail if it doesn't exist
                var material = await _materialRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No material found with Id '{request.Id}'.");

                //2. Identify who's making the change
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
                var userName = "System";

                //3. Apply updates and persist the changes
                material.Update(
                    request.Name,
                    request.Category,
                    request.Subcategory,
                    request.CasNumber,
                    request.Description,
                    userName);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update material: {ex.Message}");
            }
        }

        #endregion
    }
}
