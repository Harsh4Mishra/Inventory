using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Command.ToggleStorageSectionStatusCommand
{
    public class ToggleStorageSectionStatusCommandHandler : IRequestHandler<ToggleStorageSectionStatusCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStorageSectionRepository _storageSectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public ToggleStorageSectionStatusCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IStorageSectionRepository storageSectionRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _storageSectionRepository = storageSectionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            ToggleStorageSectionStatusCommand request,
            CancellationToken cancellationToken)
        {
            //1. Load the storage section or fail if it doesn't exist
            var storageSection = await _storageSectionRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                ?? throw new InvalidOperationException($"No storage section found with Id '{request.Id}'.");

            //2. Identify who's performing the toggle
            var userName = "System"; // TODO: Replace with actual user identification

            if (request.IsActive)
            {
                storageSection.Activate(userName);
            }
            else
            {
                storageSection.Deactivate(userName);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        #endregion
    }
}
