using AutoMapper;
using Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsQuery;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionByIdQuery
{
    public class GetBomItemDispositionByIdQueryHandler : IRequestHandler<GetBomItemDispositionByIdQuery, GetBomItemDispositionsByIdQueryResult>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomItemDispositionRepository _bomItemDispositionRepository;

        #endregion

        #region Constructor

        public GetBomItemDispositionByIdQueryHandler(
            IMapper mapper,
            IBomItemDispositionRepository bomItemDispositionRepository)
        {
            _mapper = mapper;
            _bomItemDispositionRepository = bomItemDispositionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetBomItemDispositionsByIdQueryResult> Handle(
            GetBomItemDispositionByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load disposition by ID
                var disposition = await _bomItemDispositionRepository.GetByIdAsync(request.Id, cancellationToken);

                //2. Return null if not found, or map to result
                return disposition == null
                    ? throw new InvalidOperationException($"No BOM item disposition found with ID '{request.Id}'.")
                    : _mapper.Map<GetBomItemDispositionsByIdQueryResult>(disposition);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve BOM item disposition by ID: {ex.Message}");
            }
        }

        #endregion
    }
}
