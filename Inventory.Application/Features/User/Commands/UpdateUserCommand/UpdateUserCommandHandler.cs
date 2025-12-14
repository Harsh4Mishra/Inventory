using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.User.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public UpdateUserCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Unit> Handle(
            UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load existing industry or fail if it doesn't exist
                var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new InvalidOperationException($"User not found with ID: {request.Id}");

                //2. Identify who’s making the change
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Cannot determine the current user");
                var userName = "System"; // TODO: Replace with actual user identification

                var phone = PhoneVO.From(request.PhoneNo);
                var email = EmailVO.From(request.EmailId);

                //3. Apply updates on User
                user.Update(
                    request.Name,
                    phone,
                    email,
                    request.DateOfBirth,
                    request.Gender,
                    userName);

                //Persist
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update user: {ex.Message}");
            }
        }

        #endregion
    }
}
