using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Queries.GetActiveStorageSectionsQuery
{
    public class GetActiveStorageSectionsQueryHandler : IRequestHandler<GetActiveStorageSectionsQuery, IEnumerable<GetActiveStorageSectionsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IStorageSectionRepository _storageSectionRepository;

        #endregion

        #region Constructor

        public GetActiveStorageSectionsQueryHandler(
            IMapper mapper,
            IStorageSectionRepository storageSectionRepository)
        {
            _mapper = mapper;
            _storageSectionRepository = storageSectionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveStorageSectionsQueryResult>> Handle(
            GetActiveStorageSectionsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all storage sections that are currently active
                var storageSections = await _storageSectionRepository.GetAllActiveAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActiveStorageSectionsQueryResult>>(storageSections);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active storage sections: {ex.Message}");
            }
        }

        #endregion
    }
}
