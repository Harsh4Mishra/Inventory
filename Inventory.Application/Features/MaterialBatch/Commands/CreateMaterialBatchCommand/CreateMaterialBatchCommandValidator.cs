using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Commands.CreateMaterialBatchCommand
{
    public class CreateMaterialBatchCommandValidator
        : AbstractValidator<CreateMaterialBatchCommand>
    {
        #region Fields

        private readonly IMaterialBatchRepository _materialBatchRepository;

        #endregion

        #region Ctor

        public CreateMaterialBatchCommandValidator(IMaterialBatchRepository materialBatchRepository)
        {
            _materialBatchRepository = materialBatchRepository;

            //Rule Writing
            RuleFor(x => x.MaterialId)
                .NotEmpty().WithMessage("Material ID cannot be empty.")
                .NotNull().WithMessage("Material ID is required.");

            RuleFor(x => x.BatchCode)
                .NotEmpty().WithMessage("Batch code cannot be empty.")
                .NotNull().WithMessage("Batch code is required.")
                .MinimumLength(2).WithMessage("Batch code must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Batch code cannot exceed 50 characters.")
                .Must(ValidateIfBatchCodeDoesNotExist).WithMessage("Batch code already exists");

            RuleFor(x => x.Barcode)
                .MaximumLength(100).WithMessage("Barcode cannot exceed 100 characters.")
                .Must(ValidateIfBarcodeDoesNotExist).WithMessage("Barcode already exists")
                .When(x => !string.IsNullOrWhiteSpace(x.Barcode));

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

            RuleFor(x => x.LocationText)
                .MaximumLength(200).WithMessage("Location text cannot exceed 200 characters.");

            // Validate expiry date is after manufacture date if both provided
            RuleFor(x => x)
                .Must(x => !x.ManufactureDate.HasValue || !x.ExpiryDate.HasValue || x.ExpiryDate > x.ManufactureDate)
                .WithMessage("Expiry date must be after manufacture date.");
        }

        #endregion

        #region Methods

        private bool ValidateIfBatchCodeDoesNotExist(string? batchCode)
        {
            var results = _materialBatchRepository.ExistsByBatchCodeAsync(batchCode);
            return results == null ? true : false;
        }

        private bool ValidateIfBarcodeDoesNotExist(string? barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return true;

            var results = _materialBatchRepository.ExistsByBarcodeAsync(barcode);
            return results == null ? true : false;
        }

        #endregion
    }
}
