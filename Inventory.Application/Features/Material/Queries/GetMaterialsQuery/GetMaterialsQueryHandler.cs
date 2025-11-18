using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Material.Queries.GetMaterialsQuery
{
    public class GetMaterialsQueryHandler : IRequestHandler<GetMaterialsQuery, IEnumerable<GetMaterialsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;

        #endregion

        #region Constructor

        public GetMaterialsQueryHandler(
            IMapper mapper,
            IMaterialRepository materialRepository)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetMaterialsQueryResult>> Handle(
            GetMaterialsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all materials
                var materials = await _materialRepository.GetAllAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetMaterialsQueryResult>>(materials);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve materials: {ex.Message}");
            }
        }

        #endregion
    }
}
