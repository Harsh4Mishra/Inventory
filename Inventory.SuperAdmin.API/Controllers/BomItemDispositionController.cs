using Inventory.Application.Features.BomItemDisposition.Commands.CreateBomItemDispositionCommand;
using Inventory.Application.Features.BomItemDisposition.Commands.DeleteBomItemDispositionCommand;
using Inventory.Application.Features.BomItemDisposition.Commands.UpdateBomItemDispositionCommand;
using Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionByIdQuery;
using Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsByBomItemQuery;
using Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsByDispositionQuery;
using Inventory.Application.Features.BomItemDisposition.Queries.GetBomItemDispositionsQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BomItemDispositionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BomItemDispositionController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetBomItemDispositionsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetBomItemDispositionsQueryResult>>(
                    response, true, "All BOM Item Dispositions Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByBomItem/{bomItemId}")]
        public async Task<IActionResult> GetByBomItem(int bomItemId)
        {
            try
            {
                var query = new GetBomItemDispositionsByBomItemQuery { BomItemId = bomItemId };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetBomItemDispositionsByBomItemQueryResult>>(
                    response, true, "BOM Item Dispositions Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByDisposition/{disposition}")]
        public async Task<IActionResult> GetByDisposition(string disposition)
        {
            try
            {
                var query = new GetBomItemDispositionsByDispositionQuery { Disposition = disposition };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetBomItemDispositionsByDispositionQueryResult>>(
                    response, true, "BOM Item Dispositions Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetBomItemDispositionByIdQuery { Id = id };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetBomItemDispositionsByIdQueryResult>(
                    response, true, "BOM Item Disposition Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddBomItemDisposition([FromBody] CreateBomItemDispositionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<int>(
                    response, true, "BOM Item Disposition Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBomItemDisposition([FromBody] UpdateBomItemDispositionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "BOM Item Disposition Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteBomItemDisposition([FromQuery] string dispositionId)
        {
            try
            {
                if (!int.TryParse(dispositionId, out int dispositionint))
                    return BadRequest("Invalid BOM Item Disposition ID.");

                var command = new DeleteBomItemDispositionCommand { Id = dispositionint };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "BOM Item Disposition Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
