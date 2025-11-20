using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.StorageSection.Queries.GetStorageSectionByIdQuery
{
    public class GetStorageSectionByIdQueryHandler : IRequestHandler<GetStorageSectionByIdQuery, GetStorageSectionByIdQueryResult?>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IStorageSectionRepository _storageSectionRepository;

        #endregion

        #region Constructor

        public GetStorageSectionByIdQueryHandler(
            IMapper mapper,
            IStorageSectionRepository storageSectionRepository)
        {
            _mapper = mapper;
            _storageSectionRepository = storageSectionRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetStorageSectionByIdQueryResult?> Handle(
            GetStorageSectionByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load storage section by ID
                var storageSection = await _storageSectionRepository.GetByIdAsync(request.Id, cancellationToken);

                //2. Project to the query result and return (returns null if not found)
                return _mapper.Map<GetStorageSectionByIdQueryResult?>(storageSection);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve storage section: {ex.Message}");
            }
        }

        #endregion
    }
}
