using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Commands.RejectBomCommand
{
    public class RejectBomCommandHandler : IRequestHandler<RejectBomCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBomRepository _bomRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public RejectBomCommandHandler(
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
            RejectBomCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load the BOM or fail if it doesn't exist
                var bom = await _bomRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No BOM found with Id '{request.Id}'.");

                // 2. Check if already rejected
                if (!bom.IsApproved)
                {
                    throw new InvalidOperationException($"BOM '{bom.Name}' is already rejected.");
                }

                // 3. Identify who's performing the rejection
                var userName = "System"; // TODO: Replace with actual user identification

                // 4. Reject the BOM
                bom.Reject(userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to reject BOM: {ex.Message}");
            }
        }

        #endregion
    }
}
