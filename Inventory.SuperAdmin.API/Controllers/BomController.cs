using Inventory.Application.Features.BOM.Commands.ApproveBomCommand;
using Inventory.Application.Features.BOM.Commands.CreateBomCommand;
using Inventory.Application.Features.BOM.Commands.DeleteBomCommand;
using Inventory.Application.Features.BOM.Commands.RejectBomCommand;
using Inventory.Application.Features.BOM.Commands.UpdateBomCommand;
using Inventory.Application.Features.BOM.Queries.GetApprovedBomsQuery;
using Inventory.Application.Features.BOM.Queries.GetBomByIdQuery;
using Inventory.Application.Features.BOM.Queries.GetBomsQuery;
using Inventory.Application.Features.BOM.Queries.GetPendingBomsQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BomController : Controller
    {
        private readonly IMediator _mediator;
        public BomController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetBomsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetBomsQueryResult>>(
                    response, true, "All BOMs Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetApproved")]
        public async Task<IActionResult> GetApproved()
        {
            try
            {
                var response = await _mediator.Send(new GetApprovedBomsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetApprovedBomsQueryResult>>(
                    response, true, "All Approved BOMs Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetPending")]
        public async Task<IActionResult> GetPending()
        {
            try
            {
                var response = await _mediator.Send(new GetPendingBomsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetPendingBomsQueryResult>>(
                    response, true, "All Pending BOMs Retrieved Successfully", 200);
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
                var query = new GetBomByIdQuery { Id = id };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetBomByIdQueryResult?>(
                    response, true, "BOM Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpGet("GetByCategory/{bomCategoryId}")]
        //public async Task<IActionResult> GetByCategory(Guid bomCategoryId)
        //{
        //    try
        //    {
        //        var query = new GetBomsByCategoryQuery { BomCategoryId = bomCategoryId };
        //        var response = await _mediator.Send(query);
        //        var successApiResponse = new SuccessAPIResponse<IEnumerable<GetBomsByCategoryQueryResult>>(
        //            response, true, "BOMs Retrieved Successfully", 200);
        //        return Ok(successApiResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [HttpPost("Add")]
        public async Task<IActionResult> AddBom([FromBody] CreateBomCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "BOM Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBom([FromBody] UpdateBomCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "BOM Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Approve")]
        public async Task<IActionResult> ApproveBom([FromQuery] ApproveBomCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "BOM Approved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Reject")]
        public async Task<IActionResult> RejectBom([FromQuery] RejectBomCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "BOM Rejected Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteBom([FromQuery] string bomId)
        {
            try
            {
                if (!Guid.TryParse(bomId, out Guid bomGuid))
                    return BadRequest("Invalid BOM ID.");

                var command = new DeleteBomCommand { Id = bomGuid };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "BOM Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
