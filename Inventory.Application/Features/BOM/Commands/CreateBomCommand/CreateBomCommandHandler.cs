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

namespace Inventory.Application.Features.BOM.Commands.CreateBomCommand
{
    public class CreateBomCommandHandler : IRequestHandler<CreateBomCommand, Guid>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBomRepository _bomRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CreateBomCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IBomRepository bomRepository,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _bomRepository = bomRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Handler Implementation

        public async Task<Guid> Handle(
            CreateBomCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Prevent duplicates
                if (await _bomRepository.ExistsByNameAsync(request.Name, cancellationToken))
                {
                    throw new InvalidOperationException($"A BOM named '{request.Name}' already exists.");
                }

                // 2. Validate quantity
                if (request.Quantity < 0)
                {
                    throw new InvalidOperationException("Quantity cannot be negative.");
                }

                // 3. Identify the creator
                var userName = "System"; // TODO: Replace with actual user identification

                // 4. Create and persist the new BOM
                var bom = BomDO.Create(
                    request.Name,
                    request.BomCategoryId,
                    request.Result,
                    request.Quantity,
                    userName);

                _bomRepository.Add(bom);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return bom.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create BOM: {ex.Message}");
            }
        }

        #endregion
    }
}
