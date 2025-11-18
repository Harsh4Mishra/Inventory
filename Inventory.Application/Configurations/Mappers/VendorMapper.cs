using AutoMapper;
using Inventory.Application.Features.Vendor.Commands.CreateVendorCommand;
using Inventory.Application.Features.Vendor.Commands.DeleteVendorCommand;
using Inventory.Application.Features.Vendor.Commands.ToggleVendorStatusCommand;
using Inventory.Application.Features.Vendor.Commands.UpdateVendorCommand;
using Inventory.Application.Features.Vendor.Queries.GetActiveVendorsQuery;
using Inventory.Application.Features.Vendor.Queries.GetVendorsQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class VendorMapper : Profile
    {
        public VendorMapper()
        {
            // Request Mappers
            CreateMap<CreateVendorCommand, VendorDO>();
            CreateMap<UpdateVendorCommand, VendorDO>();
            CreateMap<DeleteVendorCommand, VendorDO>();
            CreateMap<ToggleVendorStatusCommand, VendorDO>();

            // Response Mappers
            CreateMap<VendorDO, GetVendorsQueryResult>();
            CreateMap<VendorDO, GetActiveVendorsQueryResult>();
        }
    }
}
