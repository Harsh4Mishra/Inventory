using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.CreateWarehouseItemCommand
{
    public class CreateWarehouseItemCommandValidator : AbstractValidator<CreateWarehouseItemCommand>
    {
        #region Fields

        private readonly IWarehouseItemRepository _warehouseItemRepository;

        #endregion

        #region Ctor

        public CreateWarehouseItemCommandValidator(IWarehouseItemRepository warehouseItemRepository)
        {
            _warehouseItemRepository = warehouseItemRepository;

            RuleFor(x => x.MaterialBatchId)
                .NotEmpty().WithMessage("Material batch ID is required.")
                .NotNull().WithMessage("Material batch ID cannot be null.");

            RuleFor(x => x.WarehouseId)
                .NotEmpty().WithMessage("Warehouse ID is required.")
                .NotNull().WithMessage("Warehouse ID cannot be null.");

            RuleFor(x => x.AisleId)
                .NotEmpty().WithMessage("Aisle ID is required.")
                .NotNull().WithMessage("Aisle ID cannot be null.");

            RuleFor(x => x.RowId)
                .NotEmpty().WithMessage("Row ID is required.")
                .NotNull().WithMessage("Row ID cannot be null.");

            RuleFor(x => x.TrayId)
                .NotEmpty().WithMessage("Tray ID is required.")
                .NotNull().WithMessage("Tray ID cannot be null.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.")
                .NotEmpty().WithMessage("Quantity is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x)
                .MustAsync(ValidateLocationNotOccupied).WithMessage("Location is already occupied.")
                .MustAsync(ValidateMaterialBatchNotExists).WithMessage("Material batch already exists in warehouse.");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateLocationNotOccupied(CreateWarehouseItemCommand command, CancellationToken cancellationToken)
        {
            return !await _warehouseItemRepository.ExistsAtLocationAsync(
                command.WarehouseId,
                command.AisleId,
                command.RowId,
                command.TrayId,
                cancellationToken);
        }

        private async Task<bool> ValidateMaterialBatchNotExists(CreateWarehouseItemCommand command, CancellationToken cancellationToken)
        {
            return !await _warehouseItemRepository.ExistsByMaterialBatchIdAsync(command.MaterialBatchId, cancellationToken);
        }

        #endregion
    }
}
