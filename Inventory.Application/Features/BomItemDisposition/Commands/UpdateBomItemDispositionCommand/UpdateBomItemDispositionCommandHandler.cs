using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Commands.UpdateBomItemDispositionCommand
{
    public class UpdateBomItemDispositionCommandHandler
        : IRequestHandler<UpdateBomItemDispositionCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBomItemDispositionRepository _bomItemDispositionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateBomItemDispositionCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IBomItemDispositionRepository bomItemDispositionRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _bomItemDispositionRepository = bomItemDispositionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateBomItemDispositionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load existing disposition or fail if it doesn't exist
                var disposition = await _bomItemDispositionRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No BOM item disposition found with Id '{request.Id}'.");

                //2. Validate disposition type
                if (!IsValidDisposition(request.Disposition))
                {
                    throw new InvalidOperationException($"Invalid disposition type: '{request.Disposition}'. Valid values are: accept, rework, scrap");
                }

                //3. Identify who's making the change
                var userName = "System";

                //4. Apply updates and persist the changes
                disposition.Update(request.Disposition, request.Notes, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update BOM item disposition: {ex.Message}");
            }
        }

        private bool IsValidDisposition(string disposition)
        {
            var validDispositions = new[] { "accept", "rework", "scrap" };
            return validDispositions.Contains(disposition.ToLowerInvariant());
        }

        #endregion
    }
}
