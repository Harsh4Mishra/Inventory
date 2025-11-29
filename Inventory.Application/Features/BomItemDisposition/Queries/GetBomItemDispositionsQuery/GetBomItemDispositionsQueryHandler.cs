using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsQuery
{
    public class GetBomItemDispositionsQueryHandler : IRequestHandler<GetBomItemDispositionsQuery, IEnumerable<GetBomItemDispositionsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBomItemDispositionRepository _bomItemDispositionRepository;

        #endregion

        #region Constructor

        public GetBomItemDispositionsQueryHandler(
            IMapper mapper,
            IBomItemDispositionRepository bomItemDispositionRepository)
        {
            _mapper = mapper;
            _bomItemDispositionRepository = bomItemDispositionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetBomItemDispositionsQueryResult>> Handle(
            GetBomItemDispositionsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all BOM item dispositions
                var dispositions = await _bomItemDispositionRepository.GetAllAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetBomItemDispositionsQueryResult>>(dispositions);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve BOM item dispositions: {ex.Message}");
            }
        }

        #endregion
    }
}
