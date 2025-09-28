using AutoMapper;
using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventory.Application.Features.EnumType.Commands.CreateEnumTypeCommand
{
    public class CreateEnumTypeCommandHandler
        : IRequestHandler<CreateEnumTypeCommand, Guid>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEnumTypeRepository _enumTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public CreateEnumTypeCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IEnumTypeRepository enumTypeRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _enumTypeRepository = enumTypeRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<Guid> Handle(
            CreateEnumTypeCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Prevent duplicates by name
                if (await _enumTypeRepository.ExistsByNameAsync(request.Name, cancellationToken))
                {
                    throw new InvalidOperationException($"An enum type named '{request.Name}' already exists.");
                }

                // 2. Identify the creator
                //var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? throw new InvalidOperationException("Could not determine the current user.");
                var userName = "System";

                //3. Generate the next available enum type code
                var code = "ENT001"; //work on this

                // 4. Create and persist the new enum type
                var enumType = EnumTypeDO.Create(
                    request.Name,
                    code,
                    request.Description,
                    userName);

                _enumTypeRepository.Add(enumType);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return enumType.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create enum type: {ex.Message}");
            }
        }

        #endregion
    }
}
