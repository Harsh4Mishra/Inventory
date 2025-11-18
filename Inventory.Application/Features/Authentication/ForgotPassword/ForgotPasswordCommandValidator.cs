using FluentValidation;
using Inventory.Domain.Contracts;

namespace Inventory.Application.Features.Authentication.ForgotPassword
{
    public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region Ctor

        public ForgotPasswordCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.EmailId)
                .NotEmpty().WithMessage("EmailId cannot be empty.")
                .NotNull().WithMessage("EmailId is required.")
                .MinimumLength(2).WithMessage("EmailId must be at least 2 characters.")
                .MaximumLength(50).WithMessage("EmailId cannot exceed 50 characters.")
                .MustAsync(ValidateIfEmployeeExist).WithMessage("EmployeeCode not exists");

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
