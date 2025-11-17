using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Authentication.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region Ctor

        public LoginCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName cannot be empty.")
                .NotNull().WithMessage("UserName is required.")
                .MinimumLength(2).WithMessage("UserName must be at least 2 characters.")
                .MaximumLength(50).WithMessage("UserName cannot exceed 50 characters.")
                .MustAsync(ValidateIfEmployeeExist).WithMessage("EmployeeCode not exists");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .NotNull().WithMessage("Password is required.")
                .MinimumLength(2).WithMessage("Password must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Password cannot exceed 50 characters.");
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
