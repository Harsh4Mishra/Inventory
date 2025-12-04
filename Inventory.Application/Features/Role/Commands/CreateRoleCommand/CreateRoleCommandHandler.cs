using AutoMapper;
using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.Role.Commands.CreateRoleCommand
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateRoleCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IRoleRepository roleRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<int> Handle(
            CreateRoleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Prevent duplicates
                if (await _roleRepository.ExistsByNameAsync(request.Name, cancellationToken))
                {
                    throw new InvalidOperationException($"A role named '{request.Name}' already exists.");
                }

                // 2. Identify the creator
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Could not determine the current user.");
                var userName = "System"; // TODO: Replace with actual user identification

                //3. Generate the next available industry code
                var code = "IND001"; //work on this

                // 4. Create and persist the new role
                var role = RoleDO.Create(
                    request.Name,
                    code,
                    request.Description,
                    userName);

                _roleRepository.Add(role);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return role.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create role: {ex.Message}");
            }
        }

        #endregion
    }
}
