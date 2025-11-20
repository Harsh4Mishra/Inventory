using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.RowLoc.Commands.CreateRowLocCommand
{
    public class CreateRowLocCommandHandler
        : IRequestHandler<CreateRowLocCommand, Guid>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAisleRepository _aisleRepository;

        #endregion

        #region Ctor

        public CreateRowLocCommandHandler(
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

        public async Task<Guid> Handle(
            CreateRowLocCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load existing aisle or fail if it doesn't exist
                var aisle = await _aisleRepository.GetByIdToMutateAsync(request.AisleId, cancellationToken) ??
                    throw new InvalidOperationException($"No aisle found with Id '{request.AisleId}'.");

                // 2. Identify the creator
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Could not determine the current user.");
                var userName = "System";

                // 3. Create and persist the new row location
                var rowLoc = aisle.CreateRowLoc(request.Name, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return rowLoc.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
