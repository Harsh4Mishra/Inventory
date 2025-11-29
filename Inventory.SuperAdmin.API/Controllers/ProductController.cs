using Inventory.Application.Features.Product.Commands.CreateProductCommand;
using Inventory.Application.Features.Product.Commands.DeleteProductCommand;
using Inventory.Application.Features.Product.Commands.ToggleProductStatusCommand;
using Inventory.Application.Features.Product.Commands.UpdateProductCommand;
using Inventory.Application.Features.Product.Queries.GetActiveProductsQuery;
using Inventory.Application.Features.Product.Queries.GetProductByIdQuery;
using Inventory.Application.Features.Product.Queries.GetProductBySkuQuery;
using Inventory.Application.Features.Product.Queries.GetProductsQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetProductsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetProductsQueryResult>>(
                    response, true, "All Products Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAllActive")]
        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                var response = await _mediator.Send(new GetActiveProductsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveProductsQueryResult>>(
                    response, true, "All Active Products Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var query = new GetProductByIdQuery { Id = id };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetProductByIdQueryResult>(
                    response, true, "Product Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetBySku/{sku}")]
        public async Task<IActionResult> GetBySku(string sku)
        {
            try
            {
                var query = new GetProductBySkuQuery { Sku = sku };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetProductBySkuQueryResult>(
                    response, true, "Product Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "Product Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Product Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteProduct([FromQuery] string productId)
        {
            try
            {
                if (!Guid.TryParse(productId, out Guid productGuid))
                    return BadRequest("Invalid Product ID.");

                var command = new DeleteProductCommand { Id = productGuid };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Product Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> ToggleProduct([FromQuery] ToggleProductStatusCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Product Status Toggled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
