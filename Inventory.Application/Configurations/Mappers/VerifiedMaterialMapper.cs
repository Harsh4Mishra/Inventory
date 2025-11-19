using AutoMapper;
using Inventory.Application.Features.VerifiedMaterial.Commands.CreateVerifiedMaterialCommand;
using Inventory.Application.Features.VerifiedMaterial.Commands.DeleteVerifiedMaterialCommand;
using Inventory.Application.Features.VerifiedMaterial.Commands.ToggleAllotmentCommand;
using Inventory.Application.Features.VerifiedMaterial.Commands.UpdateQuantityCommand;
using Inventory.Application.Features.VerifiedMaterial.Commands.UpdateVerifiedMaterialCommand;
using Inventory.Application.Features.VerifiedMaterial.Queries.GetNonAllottedVerifiedMaterialsQuery;
using Inventory.Application.Features.VerifiedMaterial.Queries.GetQualifiedVerifiedMaterialsQuery;
using Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialByIdQuery;
using Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialsByBatchIdQuery;
using Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialsByEmpIdQuery;
using Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialsQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class VerifiedMaterialMapper : Profile
    {
        public VerifiedMaterialMapper()
        {
            // Request Mappers - Commands to Domain Objects
            CreateMap<CreateVerifiedMaterialCommand, VerifiedMaterialDO>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore ID as it will be generated
                .ForMember(dest => dest.IsAllotted, opt => opt.Ignore()) // Default value set in constructor
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore()) // Set in handler
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore()) // Set in handler
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore()) // Set in handler
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore()); // Set in handler

            CreateMap<UpdateVerifiedMaterialCommand, VerifiedMaterialDO>()
                .ForMember(dest => dest.MaterialBatchId, opt => opt.Ignore()) // Not updated in verification update
                .ForMember(dest => dest.Quantity, opt => opt.Ignore()) // Not updated in verification update
                .ForMember(dest => dest.IsAllotted, opt => opt.Ignore()) // Not updated in verification update
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore()) // Preserve original
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore()) // Preserve original
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore()) // Set in handler
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore()); // Set in handler

            CreateMap<UpdateQuantityCommand, VerifiedMaterialDO>()
                .ForMember(dest => dest.MaterialBatchId, opt => opt.Ignore()) // Not updated in quantity update
                .ForMember(dest => dest.EmpId, opt => opt.Ignore()) // Not updated in quantity update
                .ForMember(dest => dest.Specification, opt => opt.Ignore()) // Not updated in quantity update
                .ForMember(dest => dest.IsQualified, opt => opt.Ignore()) // Not updated in quantity update
                .ForMember(dest => dest.Reason, opt => opt.Ignore()) // Not updated in quantity update
                .ForMember(dest => dest.IsAllotted, opt => opt.Ignore()) // Not updated in quantity update
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore()) // Preserve original
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore()) // Preserve original
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore()) // Set in handler
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore()); // Set in handler

            CreateMap<ToggleAllotmentCommand, VerifiedMaterialDO>()
                .ForMember(dest => dest.MaterialBatchId, opt => opt.Ignore()) // Not updated in allotment toggle
                .ForMember(dest => dest.Quantity, opt => opt.Ignore()) // Not updated in allotment toggle
                .ForMember(dest => dest.EmpId, opt => opt.Ignore()) // Not updated in allotment toggle
                .ForMember(dest => dest.Specification, opt => opt.Ignore()) // Not updated in allotment toggle
                .ForMember(dest => dest.IsQualified, opt => opt.Ignore()) // Not updated in allotment toggle
                .ForMember(dest => dest.Reason, opt => opt.Ignore()) // Not updated in allotment toggle
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore()) // Preserve original
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore()) // Preserve original
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore()) // Set in handler
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore()); // Set in handler

            CreateMap<DeleteVerifiedMaterialCommand, VerifiedMaterialDO>()
                .ForMember(dest => dest.MaterialBatchId, opt => opt.Ignore())
                .ForMember(dest => dest.Quantity, opt => opt.Ignore())
                .ForMember(dest => dest.EmpId, opt => opt.Ignore())
                .ForMember(dest => dest.Specification, opt => opt.Ignore())
                .ForMember(dest => dest.IsQualified, opt => opt.Ignore())
                .ForMember(dest => dest.Reason, opt => opt.Ignore())
                .ForMember(dest => dest.IsAllotted, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore());

            // Response Mappers - Domain Objects to Query Results
            CreateMap<VerifiedMaterialDO, GetVerifiedMaterialsQueryResult>();
            CreateMap<VerifiedMaterialDO, GetVerifiedMaterialByIdQueryResult>();
            CreateMap<VerifiedMaterialDO, GetVerifiedMaterialsByBatchIdQueryResult>();
            CreateMap<VerifiedMaterialDO, GetVerifiedMaterialsByEmpIdQueryResult>();
            CreateMap<VerifiedMaterialDO, GetNonAllottedVerifiedMaterialsQueryResult>();
            CreateMap<VerifiedMaterialDO, GetQualifiedVerifiedMaterialsQueryResult>();

            // Additional custom mappings for specific scenarios
            CreateMap<VerifiedMaterialDO, GetNonAllottedVerifiedMaterialsQueryResult>();
            //.ForMember(dest => dest.IsAllotted, opt => opt.MapFrom(src => false)); // Always false for non-allotted query

            CreateMap<VerifiedMaterialDO, GetQualifiedVerifiedMaterialsQueryResult>();
                //.ForMember(dest => dest.IsQualified, opt => opt.MapFrom(src => true)); // Always true for qualified query
        }
    }
}
