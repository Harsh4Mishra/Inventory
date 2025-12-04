using Inventory.Application.Features.VerifiedMaterial.Commands.CreateVerifiedMaterialCommand;
using Inventory.Application.Features.VerifiedMaterial.Commands.DeleteVerifiedMaterialCommand;
using Inventory.Application.Features.VerifiedMaterial.Commands.ToggleAllotmentCommand;
using Inventory.Application.Features.VerifiedMaterial.Commands.UpdateQuantityCommand;
using Inventory.Application.Features.VerifiedMaterial.Commands.UpdateVerifiedMaterialCommand;
using Inventory.Application.Features.VerifiedMaterial.Queries.GetNonAllottedVerifiedMaterialsQuery;
using Inventory.Application.Features.VerifiedMaterial.Queries.GetQualifiedVerifiedMaterialsQuery;
using Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialByIdQuery;
using Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialsByBatchIdQuery;
using Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialsByEmpIdQuery;
using Inventory.Application.Features.VerifiedMaterial.Queries.GetVerifiedMaterialsQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifiedMaterialController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VerifiedMaterialController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetVerifiedMaterialsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetVerifiedMaterialsQueryResult>>(
                    response, true, "All Verified Materials Retrieved Successfully", 200);
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
                var response = await _mediator.Send(new GetVerifiedMaterialByIdQuery { Id = id });
                var successApiResponse = new SuccessAPIResponse<GetVerifiedMaterialByIdQueryResult?>(
                    response, true, "Verified Material Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByBatchId/{batchId}")]
        public async Task<IActionResult> GetByBatchId(int batchId)
        {
            try
            {
                var response = await _mediator.Send(new GetVerifiedMaterialsByBatchIdQuery { MaterialBatchId = batchId });
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetVerifiedMaterialsByBatchIdQueryResult>>(
                    response, true, "Verified Materials by Batch Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByEmpId/{empId}")]
        public async Task<IActionResult> GetByEmpId(int empId)
        {
            try
            {
                var response = await _mediator.Send(new GetVerifiedMaterialsByEmpIdQuery { EmpId = empId });
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetVerifiedMaterialsByEmpIdQueryResult>>(
                    response, true, "Verified Materials by Employee Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetNonAllotted")]
        public async Task<IActionResult> GetNonAllotted()
        {
            try
            {
                var response = await _mediator.Send(new GetNonAllottedVerifiedMaterialsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetNonAllottedVerifiedMaterialsQueryResult>>(
                    response, true, "Non-Allotted Verified Materials Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetQualified")]
        public async Task<IActionResult> GetQualified()
        {
            try
            {
                var response = await _mediator.Send(new GetQualifiedVerifiedMaterialsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetQualifiedVerifiedMaterialsQueryResult>>(
                    response, true, "Qualified Verified Materials Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddVerifiedMaterial([FromBody] CreateVerifiedMaterialCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<int>(
                    response, true, "Verified Material Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateVerification")]
        public async Task<IActionResult> UpdateVerification([FromBody] UpdateVerifiedMaterialCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Verification Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateQuantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateQuantityCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Quantity Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteVerifiedMaterial([FromQuery] string verifiedMaterialId)
        {
            try
            {
                if (!int.TryParse(verifiedMaterialId, out int verifiedMaterialint))
                    return BadRequest("Invalid Verified Material ID.");

                var command = new DeleteVerifiedMaterialCommand { Id = verifiedMaterialint };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Verified Material Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("ToggleAllotment")]
        public async Task<IActionResult> ToggleAllotment([FromQuery] ToggleAllotmentCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Allotment Status Toggled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
