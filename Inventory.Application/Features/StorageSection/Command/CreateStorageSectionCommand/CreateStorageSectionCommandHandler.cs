using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Command.CreateStorageSectionCommand
{
    public class CreateStorageSectionCommandHandler : IRequestHandler<CreateStorageSectionCommand, Guid>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStorageSectionRepository _storageSectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateStorageSectionCommandHandler(
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

        public async Task<Guid> Handle(
            CreateStorageSectionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Prevent duplicates
                if (await _storageSectionRepository.ExistsByNameAsync(request.Name, cancellationToken))
                {
                    throw new InvalidOperationException($"A storage section named '{request.Name}' already exists.");
                }

                // 2. Identify the creator
                var userName = "System"; // TODO: Replace with actual user identification

                // 3. Create and persist the new storage section
                var storageSection = StorageSectionDO.Create(
                    request.Name,
                    request.TemperatureRange,
                    request.Description,
                    userName);

                _storageSectionRepository.Add(storageSection);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return storageSection.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create storage section: {ex.Message}");
            }
        }

        #endregion
    }
}
