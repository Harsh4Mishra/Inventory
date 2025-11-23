using Inventory.Application.Features.BomItem.Commands.CreateBomItemCommand;
using Inventory.Application.Features.BomItem.Commands.DeleteBomItemCommand;
using Inventory.Application.Features.BomItem.Commands.UpdateBomItemQuantityCommand;
using Inventory.Application.Features.BomItem.Queries.GetBomItemByIdQuery;
using Inventory.Application.Features.BomItem.Queries.GetBomItemsByBomIdQuery;
using Inventory.Application.Features.BomItem.Queries.GetBomItemsByMaterialBatchQuery;
using Inventory.Application.Features.BomItem.Queries.GetBomItemsQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BomItemController : Controller
    {
        private readonly IMediator _mediator;
        public BomItemController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetBomItemsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetBomItemsQueryResult>>(
                    response, true, "All BOM Items Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByBom/{bomId}")]
        public async Task<IActionResult> GetByBom(Guid bomId)
        {
            try
            {
                var query = new GetBomItemsByBomIdQuery { BomId = bomId };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetBomItemsByBomIdQueryResult>>(
                    response, true, "BOM Items Retrieved Successfully", 200);
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
                var query = new GetBomItemByIdQuery { Id = id };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetBomItemByIdQueryResult?>(
                    response, true, "BOM Item Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByMaterialBatch/{materialBatchId}")]
        public async Task<IActionResult> GetByMaterialBatch(Guid materialBatchId)
        {
            try
            {
                var query = new GetBomItemsByMaterialBatchQuery { MaterialBatchId = materialBatchId };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetBomItemsByMaterialBatchQueryResult>>(
                    response, true, "BOM Items Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddBomItem([FromBody] CreateBomItemCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "BOM Item Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateQuantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateBomItemQuantityCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "BOM Item Quantity Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteBomItem([FromQuery] string bomItemId)
        {
            try
            {
                if (!Guid.TryParse(bomItemId, out Guid bomItemGuid))
                    return BadRequest("Invalid BOM Item ID.");

                var command = new DeleteBomItemCommand { Id = bomItemGuid };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "BOM Item Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
