using AutoMapper;
using Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsQuery;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsByDispositionQuery
{
    public class GetBomItemDispositionsByDispositionQueryHandler : IRequestHandler<GetBomItemDispositionsByDispositionQuery, IEnumerable<GetBomItemDispositionsByDispositionQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomItemDispositionRepository _bomItemDispositionRepository;

        #endregion

        #region Constructor

        public GetBomItemDispositionsByDispositionQueryHandler(
            IMapper mapper,
            IBomItemDispositionRepository bomItemDispositionRepository)
        {
            _mapper = mapper;
            _bomItemDispositionRepository = bomItemDispositionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetBomItemDispositionsByDispositionQueryResult>> Handle(
            GetBomItemDispositionsByDispositionQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load dispositions by disposition type
                var dispositions = await _bomItemDispositionRepository.GetByDispositionAsync(request.Disposition, cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetBomItemDispositionsByDispositionQueryResult>>(dispositions);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve BOM item dispositions by disposition type: {ex.Message}");
            }
        }

        #endregion
    }
}
