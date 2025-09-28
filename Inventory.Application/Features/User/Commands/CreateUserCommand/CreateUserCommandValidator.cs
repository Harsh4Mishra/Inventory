using FluentValidation;

namespace Inventory.Application.Features.User.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator
        : AbstractValidator<CreateUserCommand>
    {
        #region Constructor

        public CreateUserCommandValidator()
        {
            //Rule Writing
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(x => x.PhoneNo)
                .NotEmpty().WithMessage("Phone number is required.")
                .NotNull().WithMessage("Phone is required.");

            RuleFor(x => x.EmailId)
                .NotEmpty().WithMessage("Email is required.")
                .NotNull().WithMessage("Email is required.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .LessThan(DateOnly.FromDateTime(DateTime.Today.AddYears(-10)))
                .WithMessage("User must be at least 13 years old.");

            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("Invalid gender value.");
        }

        #endregion
    }
}
