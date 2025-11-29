using AutoMapper;
using Inventory.Application.Features.Product.Commands.CreateProductCommand;
using Inventory.Application.Features.Product.Commands.DeleteProductCommand;
using Inventory.Application.Features.Product.Commands.ToggleProductStatusCommand;
using Inventory.Application.Features.Product.Commands.UpdateProductCommand;
using Inventory.Application.Features.Product.Queries.GetActiveProductsQuery;
using Inventory.Application.Features.Product.Queries.GetProductByIdQuery;
using Inventory.Application.Features.Product.Queries.GetProductBySkuQuery;
using Inventory.Application.Features.Product.Queries.GetProductsQuery;
using Inventory.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Configurations.Mappers
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            // Request Mappers
            CreateMap<CreateProductCommand, ProductDO>();
            CreateMap<UpdateProductCommand, ProductDO>();
            CreateMap<DeleteProductCommand, ProductDO>();
            CreateMap<ToggleProductStatusCommand, ProductDO>();

            // Response Mappers
            CreateMap<ProductDO, GetProductsQueryResult>();
            CreateMap<ProductDO, GetActiveProductsQueryResult>();
            CreateMap<ProductDO, GetProductBySkuQueryResult>();
            CreateMap<ProductDO, GetProductByIdQueryResult>();
        }
    }
}
