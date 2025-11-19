using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialByIdQuery
{
    public class GetVerifiedMaterialByIdQueryHandler : IRequestHandler<GetVerifiedMaterialByIdQuery, GetVerifiedMaterialByIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IVerifiedMaterialRepository _verifiedMaterialRepository;

        #endregion

        #region Constructor

        public GetVerifiedMaterialByIdQueryHandler(
            IMapper mapper,
            IVerifiedMaterialRepository verifiedMaterialRepository)
        {
            _mapper = mapper;
            _verifiedMaterialRepository = verifiedMaterialRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetVerifiedMaterialByIdQueryResult?> Handle(
            GetVerifiedMaterialByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load verified material by ID
                var verifiedMaterial = await _verifiedMaterialRepository.GetByIdAsync(request.Id, cancellationToken);

                //2. Project to the query result and return (returns null if not found)
                return _mapper.Map<GetVerifiedMaterialByIdQueryResult?>(verifiedMaterial);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve verified material: {ex.Message}");
            }
        }

        #endregion
    }
}
