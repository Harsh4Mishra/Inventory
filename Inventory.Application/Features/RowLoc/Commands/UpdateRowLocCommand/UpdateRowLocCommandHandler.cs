using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Commands.UpdateRowLocCommand
{
    public class UpdateRowLocCommandHandler
        : IRequestHandler<UpdateRowLocCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAisleRepository _aisleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateRowLocCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IAisleRepository aisleRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _aisleRepository = aisleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            UpdateRowLocCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load existing aisle or fail if it doesn't exist
                var aisle = await _aisleRepository.GetByIdToMutateAsync(request.AisleId, cancellationToken) ??
                    throw new InvalidOperationException($"No aisle found with Id '{request.AisleId}'.");

                // 2. Identify who's making the change
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
                var userName = "System";

                // 3. Apply updates on row location
                aisle.UpdateRowLoc(request.Id, request.Name, userName);

                // 4. Persist
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update row location {ex.Message}");
            }
        }

        #endregion
    }
}
