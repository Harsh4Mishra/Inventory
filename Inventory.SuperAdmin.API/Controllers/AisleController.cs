using Inventory.Application.Features.Aisle.Commands.CreateAisleCommand;
using Inventory.Application.Features.Aisle.Commands.DeleteAisleCommand;
using Inventory.Application.Features.Aisle.Commands.UpdateAisleCommand;
using Inventory.Application.Features.Aisle.Queries.GetAislesByWarehouseIdQuery;
using Inventory.Application.Features.Aisle.Queries.GetAislesQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AisleController : Controller
    {
        private readonly IMediator _mediator;
        public AisleController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAislesQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAislesQueryResult>>(response, true, "All Aisles Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByWarehouse")]
        public async Task<IActionResult> GetByWarehouseId([FromQuery] string warehouseId)
        {
            try
            {
                if (!Guid.TryParse(warehouseId, out Guid warehouseIdGuid))
                {
                    return BadRequest("Invalid Warehouse ID.");
                }

                var response = await _mediator.Send(new GetAislesByWarehouseIdQuery() { WarehouseId = warehouseIdGuid });

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAislesByWarehouseIdQueryResult>>(response, true, "Aisles by Warehouse Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAisle([FromBody] CreateAisleCommand aisle)
        {
            try
            {
                if (aisle is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(aisle);

                var successApiResponse = new SuccessAPIResponse<Guid>(response, true, "Aisle Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAisle([FromBody] UpdateAisleCommand aisle)
        {
            try
            {
                if (aisle is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(aisle);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Aisle Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAisle([FromQuery] string aisleId)
        {
            try
            {
                if (aisleId is null)
                    throw new ArgumentException("A non-empty request body is required.");

                if (!Guid.TryParse(aisleId, out Guid aisleGuid))
                {
                    return BadRequest("Invalid Aisle ID.");
                }

                var command = new DeleteAisleCommand
                {
                    Id = aisleGuid
                };

                var response = await _mediator.Send(command);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Aisle Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
