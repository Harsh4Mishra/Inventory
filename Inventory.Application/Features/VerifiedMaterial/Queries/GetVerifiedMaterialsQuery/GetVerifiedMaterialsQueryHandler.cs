using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialsQuery
{
    public class GetVerifiedMaterialsQueryHandler : IRequestHandler<GetVerifiedMaterialsQuery, IEnumerable<GetVerifiedMaterialsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IVerifiedMaterialRepository _verifiedMaterialRepository;

        #endregion

        #region Constructor

        public GetVerifiedMaterialsQueryHandler(
            IMapper mapper,
            IVerifiedMaterialRepository verifiedMaterialRepository)
        {
            _mapper = mapper;
            _verifiedMaterialRepository = verifiedMaterialRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetVerifiedMaterialsQueryResult>> Handle(
            GetVerifiedMaterialsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all verified materials
                var verifiedMaterials = await _verifiedMaterialRepository.GetAllAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetVerifiedMaterialsQueryResult>>(verifiedMaterials);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve verified materials: {ex.Message}");
            }
        }

        #endregion
    }
}
