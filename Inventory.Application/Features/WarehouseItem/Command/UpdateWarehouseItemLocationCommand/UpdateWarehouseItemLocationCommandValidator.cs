using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.WarehouseItem.Command.UpdateWarehouseItemLocationCommand
{
    public class UpdateWarehouseItemLocationCommandValidator : AbstractValidator<UpdateWarehouseItemLocationCommand>
    {
        #region Fields

        private readonly IWarehouseItemRepository _warehouseItemRepository;

        #endregion

        #region Ctor

        public UpdateWarehouseItemLocationCommandValidator(IWarehouseItemRepository warehouseItemRepository)
        {
            _warehouseItemRepository = warehouseItemRepository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID cannot be null.");

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

            RuleFor(x => x)
                .MustAsync(ValidateLocationNotOccupied).WithMessage("Target location is already occupied.");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateLocationNotOccupied(UpdateWarehouseItemLocationCommand command, CancellationToken cancellationToken)
        {
            return !await _warehouseItemRepository.ExistsAtLocationAsync(
                command.WarehouseId,
                command.AisleId,
                command.RowId,
                command.TrayId,
                cancellationToken);
        }

        #endregion
    }
}
