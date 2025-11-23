using Inventory.Application.Features.BomCategory.Commands.CreateBomCategoryCommand;
using Inventory.Application.Features.BomCategory.Commands.DeleteBomCategoryCommand;
using Inventory.Application.Features.BomCategory.Commands.UpdateBomCategoryCommand;
using Inventory.Application.Features.BomCategory.Queries.GetBomCategoriesQuery;
using Inventory.Application.Features.BomCategory.Queries.GetBomCategoryByIdQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BomCategoryController : Controller
    {
        private readonly IMediator _mediator;
        public BomCategoryController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetBomCategoriesQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetBomCategoriesQueryResult>>(
                    response, true, "All BOM Categories Retrieved Successfully", 200);
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
                var query = new GetBomCategoryByIdQuery { Id = id };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetBomCategoryByIdQueryResult?>(
                    response, true, "BOM Category Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddBomCategory([FromBody] CreateBomCategoryCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "BOM Category Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBomCategory([FromBody] UpdateBomCategoryCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "BOM Category Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteBomCategory([FromQuery] string bomCategoryId)
        {
            try
            {
                if (!Guid.TryParse(bomCategoryId, out Guid bomCategoryGuid))
                    return BadRequest("Invalid BOM Category ID.");

                var command = new DeleteBomCategoryCommand { Id = bomCategoryGuid };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "BOM Category Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
