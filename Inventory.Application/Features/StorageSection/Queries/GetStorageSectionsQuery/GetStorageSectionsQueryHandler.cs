using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Queries.GetStorageSectionsQuery
{
    public class GetStorageSectionsQueryHandler : IRequestHandler<GetStorageSectionsQuery, IEnumerable<GetStorageSectionsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IStorageSectionRepository _storageSectionRepository;

        #endregion

        #region Constructor

        public GetStorageSectionsQueryHandler(
            IMapper mapper,
            IStorageSectionRepository storageSectionRepository)
        {
            _mapper = mapper;
            _storageSectionRepository = storageSectionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetStorageSectionsQueryResult>> Handle(
            GetStorageSectionsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all storage sections
                var storageSections = await _storageSectionRepository.GetAllAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetStorageSectionsQueryResult>>(storageSections);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve storage sections: {ex.Message}");
            }
        }

        #endregion
    }
}
