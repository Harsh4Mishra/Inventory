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
                if (!int.TryParse(rowId, out int rowIdint))
                {
                    return BadRequest("Invalid Row ID.");
                }

                var response = await _mediator.Send(new GetTraysByRowIdQuery() { RowId = rowIdint });

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
                if (!int.TryParse(trayId, out int trayIdint))
                {
                    return BadRequest("Invalid Tray ID.");
                }

                var response = await _mediator.Send(new GetTrayByIdQuery() { Id = trayIdint });

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

                var successApiResponse = new SuccessAPIResponse<int>(response, true, "Tray Created Successfully", 200);

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

                if (!int.TryParse(trayId, out int trayint))
                {
                    return BadRequest("Invalid Tray ID.");
                }

                if (aisleId is null)
                    throw new ArgumentException("A non-empty request body is required.");

                if (!int.TryParse(aisleId, out int aisleint))
                {
                    return BadRequest("Invalid Aisle ID.");
                }

                if (rowLocId is null)
                    throw new ArgumentException("A non-empty request body is required.");

                if (!int.TryParse(rowLocId, out int rowLocint))
                {
                    return BadRequest("Invalid Row Location ID.");
                }

                var command = new DeleteTrayCommand
                {
                    Id = trayint,
                    AisleId = aisleint,
                    RowLocId = rowLocint
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
