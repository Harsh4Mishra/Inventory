using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialsByEmpIdQuery
{
    public class GetVerifiedMaterialsByEmpIdQueryHandler : IRequestHandler<GetVerifiedMaterialsByEmpIdQuery, IEnumerable<GetVerifiedMaterialsByEmpIdQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IVerifiedMaterialRepository _verifiedMaterialRepository;

        #endregion

        #region Constructor

        public GetVerifiedMaterialsByEmpIdQueryHandler(
            IMapper mapper,
            IVerifiedMaterialRepository verifiedMaterialRepository)
        {
            _mapper = mapper;
            _verifiedMaterialRepository = verifiedMaterialRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetVerifiedMaterialsByEmpIdQueryResult>> Handle(
            GetVerifiedMaterialsByEmpIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load verified materials by employee ID
                var verifiedMaterials = await _verifiedMaterialRepository.GetByEmpIdAsync(request.EmpId, cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetVerifiedMaterialsByEmpIdQueryResult>>(verifiedMaterials);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve verified materials for employee: {ex.Message}");
            }
        }

        #endregion
    }
}
