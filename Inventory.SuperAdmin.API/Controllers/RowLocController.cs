using Inventory.Application.Features.RowLoc.Commands.CreateRowLocCommand;
using Inventory.Application.Features.RowLoc.Commands.DeleteRowLocCommand;
using Inventory.Application.Features.RowLoc.Commands.UpdateRowLocCommand;
using Inventory.Application.Features.RowLoc.Queries.GetRowLocByIdQuery;
using Inventory.Application.Features.RowLoc.Queries.GetRowLocsByAisleIdQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RowLocController : Controller
    {
        private readonly IMediator _mediator;

        public RowLocController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetByAisle")]
        public async Task<IActionResult> GetByAisleId([FromQuery] string aisleId)
        {
            try
            {
                if (!int.TryParse(aisleId, out int aisleIdint))
                {
                    return BadRequest("Invalid Aisle ID.");
                }

                var response = await _mediator.Send(new GetRowLocsByAisleIdQuery() { AisleId = aisleIdint });

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetRowLocsByAisleIdQueryResult>>(response, true, "Row Locations Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string rowLocId)
        {
            try
            {
                if (!int.TryParse(rowLocId, out int rowLocIdint))
                {
                    return BadRequest("Invalid Row Location ID.");
                }

                var response = await _mediator.Send(new GetRowLocByIdQuery() { Id = rowLocIdint });

                var successApiResponse = new SuccessAPIResponse<GetRowLocByIdQueryResult>(response, true, "Row Location Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddRowLoc([FromBody] CreateRowLocCommand rowLoc)
        {
            try
            {
                if (rowLoc is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(rowLoc);

                var successApiResponse = new SuccessAPIResponse<int>(response, true, "Row Location Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateRowLoc([FromBody] UpdateRowLocCommand rowLoc)
        {
            try
            {
                if (rowLoc is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(rowLoc);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Row Location Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteRowLoc([FromQuery] string rowLocId, string aisleId)
        {
            try
            {
                if (rowLocId is null)
                    throw new ArgumentException("A non-empty request body is required.");

                if (!int.TryParse(rowLocId, out int rowLocint))
                {
                    return BadRequest("Invalid Row Location ID.");
                }

                if (aisleId is null)
                    throw new ArgumentException("A non-empty request body is required.");

                if (!int.TryParse(aisleId, out int aisleint))
                {
                    return BadRequest("Invalid Aisle ID.");
                }

                var command = new DeleteRowLocCommand
                {
                    Id = rowLocint,
                    AisleId = aisleint
                };

                var response = await _mediator.Send(command);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Row Location Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
