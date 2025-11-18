using FluentValidation;
using Inventory.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Authentication.SetPassword
{
    public class SetPasswordCommandValidator : AbstractValidator<SetPasswordCommand>
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region Ctor

        public SetPasswordCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.EmailID)
                .NotEmpty().WithMessage("EmailID cannot be empty.")
                .NotNull().WithMessage("EmailID is required.")
                .MinimumLength(2).WithMessage("EmailID must be at least 8 characters.")
                .MaximumLength(50).WithMessage("EmailID cannot exceed 50 characters.")
                .Must(ValidateIfEmployeeLinkVisited).WithMessage("Already link is used")
                .MustAsync(ValidateIfEmployeeExist).WithMessage("emailId not exists");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .NotNull().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Password cannot exceed 50 characters.");
        }

        #endregion

        #region Methods

        private async Task<bool> ValidateIfEmployeeExist(string? userName, CancellationToken token)
        {
            return await _userRepository.ExistsByEmailAsync(userName!);
        }

        private bool ValidateIfEmployeeLinkVisited(string? emailId)
        {
            var results = _userRepository.ExistsByEmailAndLinkVisitedAsync(emailId!);

            return results == null ? true : false;
        }


        #endregion     
    }
}
