using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Command.DeleteStorageSectionCommand
{
    public class DeleteStorageSectionCommandHandler
        : IRequestHandler<DeleteStorageSectionCommand, Unit>
    {
        #region Fields

        private readonly IStorageSectionRepository _storageSectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteStorageSectionCommandHandler(
            IStorageSectionRepository storageSectionRepository,
            IUnitOfWork unitOfWork)
        {
            _storageSectionRepository = storageSectionRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteStorageSectionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the storage section or fail if it doesn't exist
                var storageSection = await _storageSectionRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No storage section found with Id '{request.Id}'.");

                //2. Remove and persist
                _storageSectionRepository.Remove(storageSection);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete storage section: {ex.Message}");
            }
        }

        #endregion
    }
}
