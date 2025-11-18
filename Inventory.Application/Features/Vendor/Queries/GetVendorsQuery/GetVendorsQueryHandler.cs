using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Queries.GetVendorsQuery
{
    public class GetVendorsQueryHandler : IRequestHandler<GetVendorsQuery, IEnumerable<GetVendorsQueryResult>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IVendorRepository _vendorRepository;

        #endregion

        #region Constructor

        public GetVendorsQueryHandler(
            IMapper mapper,
            IVendorRepository vendorRepository)
        {
            _mapper = mapper;
            _vendorRepository = vendorRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<IEnumerable<GetVendorsQueryResult>> Handle(
            GetVendorsQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load all vendors
                var vendors = await _vendorRepository.GetAllAsync(cancellationToken);

                //2. Project to the query result and return
                return _mapper.Map<IEnumerable<GetVendorsQueryResult>>(vendors);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve vendors: {ex.Message}");
            }
        }

        #endregion
    }
}
