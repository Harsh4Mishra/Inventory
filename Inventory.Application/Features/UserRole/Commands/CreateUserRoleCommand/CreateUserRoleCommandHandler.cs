using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.UserRole.Commands.CreateUserRoleCommand
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, int>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateUserRoleCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IUserRoleRepository userRoleRepository,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<int> Handle(
            CreateUserRoleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Validate user exists
                var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
                if (user == null)
                {
                    throw new InvalidOperationException($"User with ID '{request.UserId}' not found.");
                }

                // 2. Validate user is active
                if (!user.IsActive)
                {
                    throw new InvalidOperationException($"User with ID '{request.UserId}' is inactive.");
                }

                // 3. Validate role exists and is active
                var role = await _roleRepository.GetByIdAsync(request.RoleId, cancellationToken);
                if (role == null)
                {
                    throw new InvalidOperationException($"Role with ID '{request.RoleId}' not found or inactive.");
                }

                // 4. Prevent duplicate assignments
                if (await _userRoleRepository.ActiveExistsByUserAndRoleAsync(request.UserId, request.RoleId, cancellationToken))
                {
                    throw new InvalidOperationException($"User '{request.UserId}' is already assigned to role '{request.RoleId}'.");
                }

                // 5. Identify the creator
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Could not determine the current user.");
                var userName = "System"; // TODO: Replace with actual user identification

                // 6. Create and persist the new user-role assignment
                var userRole = UserRoleDO.Create(
                    request.UserId,
                    request.RoleId,
                    userName);

                _userRoleRepository.Add(userRole);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return userRole.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create user-role assignment: {ex.Message}");
            }
        }

        #endregion
    }
}
