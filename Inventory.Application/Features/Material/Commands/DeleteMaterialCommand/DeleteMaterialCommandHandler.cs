using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Commands.DeleteMaterialCommand
{
    public class DeleteMaterialCommandHandler
        : IRequestHandler<DeleteMaterialCommand, Unit>
    {
        #region Fields

        private readonly IMaterialRepository _materialRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DeleteMaterialCommandHandler(
            IMaterialRepository materialRepository,
            IUnitOfWork unitOfWork)
        {
            _materialRepository = materialRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(
            DeleteMaterialCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load the material or fail if it doesn't exist
                var material = await _materialRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"No material found with Id '{request.Id}'.");

                //2. Remove and persist
                _materialRepository.Remove(material);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete material: {ex.Message}");
            }
        }

        #endregion
    }
}
