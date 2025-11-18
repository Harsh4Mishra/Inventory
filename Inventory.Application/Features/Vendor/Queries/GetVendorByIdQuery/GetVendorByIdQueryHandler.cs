using AutoMapper;
using Inventory.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Vendor.Queries.GetVendorByIdQuery
{
    public class GetVendorByIdQueryHandler : IRequestHandler<GetVendorByIdQuery, GetVendorByIdQueryResult>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IVendorRepository _vendorRepository;

        #endregion

        #region Constructor

        public GetVendorByIdQueryHandler(
            IMapper mapper,
            IVendorRepository vendorRepository)
        {
            _mapper = mapper;
            _vendorRepository = vendorRepository;
        }

        #endregion

        #region Handler Implementation

        public async Task<GetVendorByIdQueryResult> Handle(
            GetVendorByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                //1. Load vendor by ID
                var vendor = await _vendorRepository.GetByIdAsync(request.Id, cancellationToken);

                //2. If not found, throw exception
                if (vendor == null)
                {
                    throw new InvalidOperationException($"No vendor found with Id '{request.Id}'.");
                }

                //3. Project to the query result and return
                return _mapper.Map<GetVendorByIdQueryResult>(vendor);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve vendor: {ex.Message}");
            }
        }

        #endregion
    }
}
