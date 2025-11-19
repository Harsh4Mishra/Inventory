using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Queries.GetQualifiedVerifiedMaterialsQuery
{
    public class GetQualifiedVerifiedMaterialsQueryHandler : IRequestHandler<GetQualifiedVerifiedMaterialsQuery, IEnumerable<GetQualifiedVerifiedMaterialsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IVerifiedMaterialRepository _verifiedMaterialRepository;

        #endregion

        #region Constructor

        public GetQualifiedVerifiedMaterialsQueryHandler(
            IMapper mapper,
            IVerifiedMaterialRepository verifiedMaterialRepository)
        {
            _mapper = mapper;
            _verifiedMaterialRepository = verifiedMaterialRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetQualifiedVerifiedMaterialsQueryResult>> Handle(
            GetQualifiedVerifiedMaterialsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load qualified verified materials
                var verifiedMaterials = await _verifiedMaterialRepository.GetQualifiedAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetQualifiedVerifiedMaterialsQueryResult>>(verifiedMaterials);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve qualified verified materials: {ex.Message}");
            }
        }

        #endregion
    }
}
