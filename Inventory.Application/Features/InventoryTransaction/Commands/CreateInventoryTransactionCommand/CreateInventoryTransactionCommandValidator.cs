using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryTransaction.Commands.CreateInventoryTransactionCommand
{
    public class CreateInventoryTransactionCommandValidator : AbstractValidator<CreateInventoryTransactionCommand>
    {
        #region Fields

        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;

        #endregion

        #region Ctor

        public CreateInventoryTransactionCommandValidator(IInventoryTransactionRepository inventoryTransactionRepository)
        {
            _inventoryTransactionRepository = inventoryTransactionRepository;

            RuleFor(x => x.TransactionType)
                .NotEmpty().WithMessage("Transaction type cannot be empty.")
                .NotNull().WithMessage("Transaction type is required.")
                .Must(BeValidTransactionType).WithMessage("Transaction type must be one of: receive, issue, transfer, adjust, allocate, deallocate");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity cannot be empty.")
                .NotNull().WithMessage("Quantity is required.")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy cannot be empty.")
                .NotNull().WithMessage("CreatedBy is required.");

            RuleFor(x => x)
                .Must(HaveEitherMaterialOrProduct).WithMessage("Either MaterialBatchId or ProductId must be provided.");

            RuleFor(x => x.Cost)
                .GreaterThanOrEqualTo(0).When(x => x.Cost.HasValue)
                .WithMessage("Cost must be greater than or equal to 0.");

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("Notes cannot exceed 500 characters.");
        }

        #endregion

        #region Methods

        private bool BeValidTransactionType(string transactionType)
        {
            var validTypes = new[] { "receive", "issue", "transfer", "adjust", "allocate", "deallocate" };
            return validTypes.Contains(transactionType?.ToLower());
        }

        private bool HaveEitherMaterialOrProduct(CreateInventoryTransactionCommand command)
        {
            return command.MaterialBatchId.HasValue || command.ProductId.HasValue;
        }

        #endregion
    }
}
