using AutoMapper;
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

namespace Inventory.Application.Features.BomItemDisposition.Commands.CreateBomItemDispositionCommand
{
    public class CreateBomItemDispositionCommandHandler : IRequestHandler<CreateBomItemDispositionCommand, int>
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBomItemDispositionRepository _bomItemDispositionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public CreateBomItemDispositionCommandHandler(
            IHttpContextAccessor httpContextAccessor,
            IBomItemDispositionRepository bomItemDispositionRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _bomItemDispositionRepository = bomItemDispositionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region Handler Implementation

        public async Task<int> Handle(
            CreateBomItemDispositionCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1. Validate disposition type
                if (!IsValidDisposition(request.Disposition))
                {
                    throw new InvalidOperationException($"Invalid disposition type: '{request.Disposition}'. Valid values are: accept, rework, scrap");
                }

                // 2. Identify the creator
                var userName = "System"; // TODO: Replace with actual user identification

                // 3. Create and persist the new disposition
                var disposition = BomItemDispositionDO.Create(
                    request.BomItemId,
                    request.Disposition,
                    request.Notes,
                    userName);

                _bomItemDispositionRepository.Add(disposition);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return disposition.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create BOM item disposition: {ex.Message}");
            }
        }

        private bool IsValidDisposition(string disposition)
        {
            var validDispositions = new[] { "accept", "rework", "scrap" };
            return validDispositions.Contains(disposition.ToLowerInvariant());
        }

        #endregion
    }
}
