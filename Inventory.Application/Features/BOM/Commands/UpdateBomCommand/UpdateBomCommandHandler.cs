using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BOM.Commands.UpdateBomCommand
{
    public class UpdateBomCommandHandler : IRequestHandler<UpdateBomCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBomRepository _bomRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateBomCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IBomRepository bomRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _bomRepository = bomRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateBomCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Load existing BOM or fail if it doesn't exist
                var bom = await _bomRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No BOM found with Id '{request.Id}'.");

                // 2. Check if new name already exists (excluding current BOM)
                if (request.Name != bom.Name)
                {
                    var existingBom = await _bomRepository.GetByNameAsync(request.Name, cancellationToken);
                    if (existingBom != null && existingBom.Id != request.Id)
                    {
                        throw new InvalidOperationException($"A BOM named '{request.Name}' already exists.");
                    }
                }

                // 3. Validate quantity
                if (request.Quantity < 0)
                {
                    throw new InvalidOperationException("Quantity cannot be negative.");
                }

                // 4. Identify who's making the change
                var userName = "System";

                // 5. Apply updates and persist the changes
                bom.Update(
                    request.Name,
                    request.BomCategoryId,
                    request.Result,
                    request.Quantity,
                    userName);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update BOM: {ex.Message}");
            }
        }

        #endregion
    }
}
