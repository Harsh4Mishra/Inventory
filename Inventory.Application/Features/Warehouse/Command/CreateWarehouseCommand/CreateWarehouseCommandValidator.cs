using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Warehouse.Command.CreateWarehouseCommand
{
    public class CreateWarehouseCommandValidator
        : AbstractValidator<CreateWarehouseCommand>
    {
        #region Fields

        private readonly IWarehouseRepository _warehouseRepository;

        #endregion

        #region Ctor

        public CreateWarehouseCommandValidator(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;

            //Rule Writing
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .MustAsync(ValidateIfWarehouseDoesNotExist).WithMessage("Warehouse already exists");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfWarehouseDoesNotExist(string? name, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(name))
                return true;

            var exists = await _warehouseRepository.ExistsByNameAsync(name, cancellationToken);
            return !exists;
        }

        #endregion
    }
}
