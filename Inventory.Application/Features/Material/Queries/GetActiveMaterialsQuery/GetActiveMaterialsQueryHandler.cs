using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Queries.GetActiveMaterialsQuery
{
    public class GetActiveMaterialsQueryHandler : IRequestHandler<GetActiveMaterialsQuery, IEnumerable<GetActiveMaterialsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;

        #endregion

        #region Constructor

        public GetActiveMaterialsQueryHandler(
            IMapper mapper,
            IMaterialRepository materialRepository)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveMaterialsQueryResult>> Handle(
            GetActiveMaterialsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all materials that are currently active
                var materials = await _materialRepository.GetAllActiveAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActiveMaterialsQueryResult>>(materials);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active materials: {ex.Message}");
            }
        }

        #endregion
    }
}
