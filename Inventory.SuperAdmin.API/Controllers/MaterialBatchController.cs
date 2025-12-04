using Inventory.Application.Features.MaterialBatch.Commands.ConsumeMaterialBatchQuantityCommand;
using Inventory.Application.Features.MaterialBatch.Commands.CreateMaterialBatchCommand;
using Inventory.Application.Features.MaterialBatch.Commands.DeleteMaterialBatchCommand;
using Inventory.Application.Features.MaterialBatch.Commands.ToggleMaterialBatchStatusCommand;
using Inventory.Application.Features.MaterialBatch.Commands.UpdateMaterialBatchCommand;
using Inventory.Application.Features.MaterialBatch.Commands.UpdateMaterialBatchQuantityCommand;
using Inventory.Application.Features.MaterialBatch.Queries.GetActiveMaterialBatchesQuery;
using Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchByBatchCodeQuery;
using Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchByIdQuery;
using Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchesByMaterialIdQuery;
using Inventory.Application.Features.MaterialBatch.Queries.GetMaterialBatchesQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialBatchController : Controller
    {
        private readonly IMediator _mediator;
        public MaterialBatchController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetMaterialBatchesQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetMaterialBatchesQueryResult>>(
                    response, true, "All Material Batches Retrieved Successfully", 200);
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
                var response = await _mediator.Send(new GetActiveMaterialBatchesQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveMaterialBatchesQueryResult>>(
                    response, true, "All Active Material Batches Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string materialBatchId)
        {
            try
            {
                if (!int.TryParse(materialBatchId, out int materialBatchint))
                    return BadRequest("Invalid Material Batch ID.");

                var query = new GetMaterialBatchByIdQuery { Id = materialBatchint };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetMaterialBatchByIdQueryResult>(
                    response, true, "Material Batch Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByBatchCode")]
        public async Task<IActionResult> GetByBatchCode([FromQuery] string batchCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(batchCode))
                    return BadRequest("Batch Code is required.");

                var query = new GetMaterialBatchByBatchCodeQuery { BatchCode = batchCode };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetMaterialBatchByBatchCodeQueryResult>(
                    response, true, "Material Batch Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByMaterialId")]
        public async Task<IActionResult> GetByMaterialId([FromQuery] string materialId)
        {
            try
            {
                if (!int.TryParse(materialId, out int materialint))
                    return BadRequest("Invalid Material ID.");

                var query = new GetMaterialBatchesByMaterialIdQuery { MaterialId = materialint };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetMaterialBatchesByMaterialIdQueryResult>>(
                    response, true, "Material Batches Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddMaterialBatch([FromBody] CreateMaterialBatchCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<int>(
                    response, true, "Material Batch Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateMaterialBatch([FromBody] UpdateMaterialBatchCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Material Batch Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateQuantity")]
        public async Task<IActionResult> UpdateMaterialBatchQuantity([FromBody] UpdateMaterialBatchQuantityCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Material Batch Quantity Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("ConsumeQuantity")]
        public async Task<IActionResult> ConsumeMaterialBatchQuantity([FromBody] ConsumeMaterialBatchQuantityCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Material Batch Quantity Consumed Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteMaterialBatch([FromQuery] string materialBatchId)
        {
            try
            {
                if (!int.TryParse(materialBatchId, out int materialBatchint))
                    return BadRequest("Invalid Material Batch ID.");

                var command = new DeleteMaterialBatchCommand { Id = materialBatchint };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Material Batch Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> ToggleMaterialBatch([FromQuery] ToggleMaterialBatchStatusCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Material Batch Status Toggled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
