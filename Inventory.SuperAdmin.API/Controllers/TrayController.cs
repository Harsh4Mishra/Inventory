using Inventory.Application.Features.Tray.Commands.CreateTrayCommand;
using Inventory.Application.Features.Tray.Commands.DeleteTrayCommand;
using Inventory.Application.Features.Tray.Commands.UpdateTrayCommand;
using Inventory.Application.Features.Tray.Queries.GetTrayByIdQuery;
using Inventory.Application.Features.Tray.Queries.GetTraysByRowIdQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrayController : Controller
    {
        private readonly IMediator _mediator;

        public TrayController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetByRow")]
        public async Task<IActionResult> GetByRowId([FromQuery] string rowId)
        {
            try
            {
                if (!Guid.TryParse(rowId, out Guid rowIdGuid))
                {
                    return BadRequest("Invalid Row ID.");
                }

                var response = await _mediator.Send(new GetTraysByRowIdQuery() { RowId = rowIdGuid });

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetTraysByRowIdQueryResult>>(response, true, "Trays Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string trayId)
        {
            try
            {
                if (!Guid.TryParse(trayId, out Guid trayIdGuid))
                {
                    return BadRequest("Invalid Tray ID.");
                }

                var response = await _mediator.Send(new GetTrayByIdQuery() { Id = trayIdGuid });

                var successApiResponse = new SuccessAPIResponse<GetTrayByIdQueryResult>(response, true, "Tray Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddTray([FromBody] CreateTrayCommand tray)
        {
            try
            {
                if (tray is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(tray);

                var successApiResponse = new SuccessAPIResponse<Guid>(response, true, "Tray Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTray([FromBody] UpdateTrayCommand tray)
        {
            try
            {
                if (tray is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(tray);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Tray Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteTray([FromQuery] string trayId, string aisleId, string rowLocId)
        {
            try
            {
                if (trayId is null)
                    throw new ArgumentException("A non-empty request body is required.");

                if (!Guid.TryParse(trayId, out Guid trayGuid))
                {
                    return BadRequest("Invalid Tray ID.");
                }

                if (aisleId is null)
                    throw new ArgumentException("A non-empty request body is required.");

                if (!Guid.TryParse(aisleId, out Guid aisleGuid))
                {
                    return BadRequest("Invalid Aisle ID.");
                }

                if (rowLocId is null)
                    throw new ArgumentException("A non-empty request body is required.");

                if (!Guid.TryParse(rowLocId, out Guid rowLocGuid))
                {
                    return BadRequest("Invalid Row Location ID.");
                }

                var command = new DeleteTrayCommand
                {
                    Id = trayGuid,
                    AisleId = aisleGuid,
                    RowLocId = rowLocGuid
                };

                var response = await _mediator.Send(command);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Tray Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
