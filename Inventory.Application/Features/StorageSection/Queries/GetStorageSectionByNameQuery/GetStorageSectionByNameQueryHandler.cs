using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Queries.GetStorageSectionByNameQuery
{
    public class GetStorageSectionByNameQueryHandler : IRequestHandler<GetStorageSectionByNameQuery, GetStorageSectionByNameQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IStorageSectionRepository _storageSectionRepository;

        #endregion

        #region Constructor

        public GetStorageSectionByNameQueryHandler(
            IMapper mapper,
            IStorageSectionRepository storageSectionRepository)
        {
            _mapper = mapper;
            _storageSectionRepository = storageSectionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetStorageSectionByNameQueryResult?> Handle(
            GetStorageSectionByNameQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load storage section by name
                var storageSection = await _storageSectionRepository.GetByNameAsync(request.Name, cancellationToken);

                //2. Project to the query result and return (returns null if not found)
                return _mapper.Map<GetStorageSectionByNameQueryResult?>(storageSection);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve storage section: {ex.Message}");
            }
        }

        #endregion
    }
}
