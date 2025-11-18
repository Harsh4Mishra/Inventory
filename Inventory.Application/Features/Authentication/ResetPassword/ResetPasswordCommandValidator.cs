using FluentValidation;
using Inventory.Domain.Contracts;

namespace Inventory.Application.Features.Authentication.ResetPassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region Ctor

        public ResetPasswordCommandValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.EmailId)
                .NotEmpty().WithMessage("EmailId cannot be empty.")
                .NotNull().WithMessage("EmailId is required.")
                .MinimumLength(8).WithMessage("EmailId must be at least 8 characters.")
                .MaximumLength(50).WithMessage("EmailId cannot exceed 50 characters.")
                .MustAsync(ValidateIfEmployeeExist).WithMessage("EmployeeCode not exists");

            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("Old Password cannot be empty.")
                .NotNull().WithMessage("Old Password is required.")
                .MinimumLength(8).WithMessage("Old Password must be at least 8 characters.")
                .MaximumLength(50).WithMessage("Old Password cannot exceed 50 characters.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New Password cannot be empty.")
                .NotNull().WithMessage("New Password is required.")
                .MinimumLength(8).WithMessage("New Password must be at least 8 characters.")
                .MaximumLength(50).WithMessage("New Password cannot exceed 50 characters.");
            _userRepository = userRepository;
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfEmployeeExist(string? userName, CancellationToken token)
        {
            return await _userRepository.ExistsByEmailAsync(userName!);
        }

        #endregion      
    }
}
