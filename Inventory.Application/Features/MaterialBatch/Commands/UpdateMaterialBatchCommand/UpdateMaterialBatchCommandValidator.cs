using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.MaterialBatch.Commands.UpdateMaterialBatchCommand
{
    public class UpdateMaterialBatchCommandValidator : AbstractValidator<UpdateMaterialBatchCommand>
    {
        #region Fields

        private readonly IMaterialBatchRepository _materialBatchRepository;

        #endregion

        #region Ctor

        public UpdateMaterialBatchCommandValidator(IMaterialBatchRepository materialBatchRepository)
        {
            _materialBatchRepository = materialBatchRepository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull().WithMessage("Id cannot be null.");

            RuleFor(x => x.Barcode)
                .MaximumLength(100).WithMessage("Barcode cannot exceed 100 characters.")
                .Must(ValidateIfBarcodeDoesNotExist).WithMessage("Barcode already exists")
                .When(x => !string.IsNullOrWhiteSpace(x.Barcode));

            RuleFor(x => x.LocationText)
                .MaximumLength(200).WithMessage("Location text cannot exceed 200 characters.");

            // Validate expiry date is after manufacture date if both provided
            RuleFor(x => x)
                .Must(x => !x.ManufactureDate.HasValue || !x.ExpiryDate.HasValue || x.ExpiryDate > x.ManufactureDate)
                .WithMessage("Expiry date must be after manufacture date.");
        }

        #endregion

        #region Methods

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
