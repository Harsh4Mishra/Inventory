using AutoMapper;
using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.User.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, Guid>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateUserCommandHandler(
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

        public async Task<Guid> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Check for duplicates by email
                if (await _userRepository.ExistsByMobileNumberAsync(request.PhoneNo.PhoneNo.ToString(), cancellationToken))
                {
                    throw new InvalidOperationException($"User with phone number '{request.PhoneNo}' already exists.");
                }

                // 2. Identify the creator
                var userName = "System"; // TODO: Replace with actual user identification

                // 3. Create and persist the new user
                var user = UserDO.Create(
                    request.Name,
                    request.PhoneNo,
                    request.EmailId,
                    request.DateOfBirth,
                    request.Gender,
                    userName);

                //4. Create and persist the new user
                _userRepository.Add(user);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return user.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create user: {ex.Message}");
            }
        }

        #endregion
    }
}
