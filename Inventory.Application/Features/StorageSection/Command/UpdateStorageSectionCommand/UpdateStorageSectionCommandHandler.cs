using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Command.UpdateStorageSectionCommand
{
    public class UpdateStorageSectionCommandHandler
        : IRequestHandler<UpdateStorageSectionCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStorageSectionRepository _storageSectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UpdateStorageSectionCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IStorageSectionRepository storageSectionRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _storageSectionRepository = storageSectionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region methods

        public async Task<Unit> Handle(
            UpdateStorageSectionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load existing storage section or fail if it doesn't exist
                var storageSection = await _storageSectionRepository.GetByIdToMutateAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No storage section found with Id '{request.Id}'.");

                //2. Identify who's making the change
                var userName = "System";

                //3. Apply updates and persist the changes
                storageSection.Update(request.Name, request.TemperatureRange, request.Description, userName);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update storage section: {ex.Message}");
            }
        }

        #endregion
    }
}
