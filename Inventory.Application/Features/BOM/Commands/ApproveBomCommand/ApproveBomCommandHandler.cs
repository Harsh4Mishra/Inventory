using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Commands.ApproveBomCommand
{
    public class ApproveBomCommandHandler : IRequestHandler<ApproveBomCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBomRepository _bomRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public ApproveBomCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IBomRepository bomRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _bomRepository = bomRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            ApproveBomCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the BOM or fail if it doesn't exist
                var bom = await _bomRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No BOM found with Id '{request.Id}'.");

                // 2. Check if already approved
                if (bom.IsApproved)
                {
                    throw new InvalidOperationException($"BOM '{bom.Name}' is already approved.");
                }

                // 3. Identify who's performing the approval
                var userName = "System"; // TODO: Replace with actual user identification

                // 4. Approve the BOM
                bom.Approve(userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to approve BOM: {ex.Message}");
            }
        }

        #endregion
    }
}
