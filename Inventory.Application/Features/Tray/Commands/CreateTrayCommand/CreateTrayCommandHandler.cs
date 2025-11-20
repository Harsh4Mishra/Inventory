using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Tray.Commands.CreateTrayCommand
{
    public class CreateTrayCommandHandler
        : IRequestHandler<CreateTrayCommand, Guid>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAisleRepository _aisleRepository;

        #endregion

        #region Ctor

        public CreateTrayCommandHandler(
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
            CreateTrayCommand request,
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

                // 3. Create and persist the new tray
                var tray = aisle.CreateTray(request.RowLocId, request.Capacity, request.Description, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return tray.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
