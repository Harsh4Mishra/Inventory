using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Allocation.Commands.CreateAllocationCommand
{
    public class CreateAllocationCommandValidator : AbstractValidator<CreateAllocationCommand>
    {
        #region Fields

        private readonly IAllocationRepository _allocationRepository;

        #endregion

        #region Ctor

        public CreateAllocationCommandValidator(IAllocationRepository allocationRepository)
        {
            _allocationRepository = allocationRepository;

            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("Order ID cannot be empty.")
                .NotNull().WithMessage("Order ID is required.")
                .NotEqual(Guid.Empty).WithMessage("Order ID cannot be empty GUID.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID cannot be empty.")
                .NotNull().WithMessage("Product ID is required.")
                .NotEqual(Guid.Empty).WithMessage("Product ID cannot be empty GUID.");

            RuleFor(x => x.MaterialBatchId)
                .NotEmpty().WithMessage("Material Batch ID cannot be empty.")
                .NotNull().WithMessage("Material Batch ID is required.")
                .NotEqual(Guid.Empty).WithMessage("Material Batch ID cannot be empty GUID.");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity cannot be empty.")
                .NotNull().WithMessage("Quantity is required.")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }

        #endregion
    }
}
