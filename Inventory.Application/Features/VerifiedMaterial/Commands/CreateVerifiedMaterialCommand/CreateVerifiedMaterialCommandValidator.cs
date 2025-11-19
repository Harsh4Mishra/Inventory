using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Commands.CreateVerifiedMaterialCommand
{
    public class CreateVerifiedMaterialCommandValidator
        : AbstractValidator<CreateVerifiedMaterialCommand>
    {
        #region Fields

        private readonly IVerifiedMaterialRepository _verifiedMaterialRepository;

        #endregion

        #region Ctor

        public CreateVerifiedMaterialCommandValidator(IVerifiedMaterialRepository verifiedMaterialRepository)
        {
            _verifiedMaterialRepository = verifiedMaterialRepository;

            RuleFor(x => x.MaterialBatchId)
                .NotEmpty().WithMessage("Material Batch ID cannot be empty.")
                .NotNull().WithMessage("Material Batch ID is required.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                .LessThan(1000000).WithMessage("Quantity cannot exceed 1,000,000.");

            RuleFor(x => x.Reason)
                .MaximumLength(500).WithMessage("Reason cannot exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Reason));

            RuleFor(x => x.EmpId)
                .NotEmpty().WithMessage("Employee ID cannot be empty if provided.")
                .When(x => x.EmpId.HasValue);
        }

        #endregion
    }
}
