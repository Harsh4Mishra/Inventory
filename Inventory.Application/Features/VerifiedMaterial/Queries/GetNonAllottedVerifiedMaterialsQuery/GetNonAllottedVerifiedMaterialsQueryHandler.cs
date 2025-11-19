using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Queries.GetNonAllottedVerifiedMaterialsQuery
{
    public class GetNonAllottedVerifiedMaterialsQueryHandler : IRequestHandler<GetNonAllottedVerifiedMaterialsQuery, IEnumerable<GetNonAllottedVerifiedMaterialsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IVerifiedMaterialRepository _verifiedMaterialRepository;

        #endregion

        #region Constructor

        public GetNonAllottedVerifiedMaterialsQueryHandler(
            IMapper mapper,
            IVerifiedMaterialRepository verifiedMaterialRepository)
        {
            _mapper = mapper;
            _verifiedMaterialRepository = verifiedMaterialRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetNonAllottedVerifiedMaterialsQueryResult>> Handle(
            GetNonAllottedVerifiedMaterialsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load non-allotted verified materials
                var verifiedMaterials = await _verifiedMaterialRepository.GetNonAllottedAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetNonAllottedVerifiedMaterialsQueryResult>>(verifiedMaterials);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve non-allotted verified materials: {ex.Message}");
            }
        }

        #endregion
    }
}
