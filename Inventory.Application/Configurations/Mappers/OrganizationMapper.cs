using AutoMapper;
using Inventory.Application.Features.Organization.Commands.CreateOrganizationCommand;
using Inventory.Application.Features.Organization.Commands.DeleteOrganizationCommand;
using Inventory.Application.Features.Organization.Commands.ToggleOrganizationStatusCommand;
using Inventory.Application.Features.Organization.Commands.UpdateOrganizationCommand;
using Inventory.Application.Features.Organization.Queries.GetActiveOrganizationQuery;
using Inventory.Application.Features.Organization.Queries.GetOrganizationQuery;
using Inventory.Domain.DomainObjects;

namespace Inventory.Application.Configurations.Mappers
{
    public class OrganizationMapper : Profile
    {
        public OrganizationMapper()
        {
            // Request Mappers
            CreateMap<CreateOrganizationCommand, OrganizationDO>();
            CreateMap<UpdateOrganizationCommand, OrganizationDO>();
            CreateMap<DeleteOrganizationCommand, OrganizationDO>();
            CreateMap<ToggleOrganizationStatusCommand, OrganizationDO>();

            // Response Mappers
            CreateMap<OrganizationDO, GetOrganizationQueryResult>();
            CreateMap<OrganizationDO, GetActiveOrganizationQueryResult>();
        }
    }
}
