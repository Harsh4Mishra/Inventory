using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Queries.GetActiveVendorsQuery
{
    public class GetActiveVendorsQueryHandler : IRequestHandler<GetActiveVendorsQuery, IEnumerable<GetActiveVendorsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IVendorRepository _vendorRepository;

        #endregion

        #region Constructor

        public GetActiveVendorsQueryHandler(
            IMapper mapper,
            IVendorRepository vendorRepository)
        {
            _mapper = mapper;
            _vendorRepository = vendorRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetActiveVendorsQueryResult>> Handle(
            GetActiveVendorsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all vendors that are currently active
                var vendors = await _vendorRepository.GetAllActiveAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetActiveVendorsQueryResult>>(vendors);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve active vendors: {ex.Message}");
            }
        }

        #endregion
    }
}
