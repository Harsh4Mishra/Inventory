using Inventory.Application.Features.Allocation.Commands.CreateAllocationCommand;
using Inventory.Application.Features.Allocation.Commands.DeleteAllocationCommand;
using Inventory.Application.Features.Allocation.Commands.UpdateAllocationQuantityCommand;
using Inventory.Application.Features.Allocation.Commands.UpdateAllocationStatusCommand;
using Inventory.Application.Features.Allocation.Queries.GetActiveAllocationsQuery;
using Inventory.Application.Features.Allocation.Queries.GetAllocationByIdQuery;
using Inventory.Application.Features.Allocation.Queries.GetAllocationsByMaterialBatchIdQuery;
using Inventory.Application.Features.Allocation.Queries.GetAllocationsByOrderIdQuery;
using Inventory.Application.Features.Allocation.Queries.GetAllocationsByProductIdQuery;
using Inventory.Application.Features.Allocation.Queries.GetAllocationsByStatusQuery;
using Inventory.Application.Features.Allocation.Queries.GetAllocationsQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocationController : Controller
    {
        private readonly IMediator _mediator;

        public AllocationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllocationsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllocationsQueryResult>>(
                    response, true, "All Allocations Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetActive")]
        public async Task<IActionResult> GetActive()
        {
            try
            {
                var response = await _mediator.Send(new GetActiveAllocationsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveAllocationsQueryResult>>(
                    response, true, "Active Allocations Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByOrder/{orderId}")]
        public async Task<IActionResult> GetByOrder(int orderId)
        {
            try
            {
                var query = new GetAllocationsByOrderIdQuery { OrderId = orderId };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllocationsByOrderIdQueryResult>>(
                    response, true, "Allocations for Order Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByProduct/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            try
            {
                var query = new GetAllocationsByProductIdQuery { ProductId = productId };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllocationsByProductIdQueryResult>>(
                    response, true, "Allocations for Product Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByMaterialBatch/{materialBatchId}")]
        public async Task<IActionResult> GetByMaterialBatch(int materialBatchId)
        {
            try
            {
                var query = new GetAllocationsByMaterialBatchIdQuery { MaterialBatchId = materialBatchId };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllocationsByMaterialBatchIdQueryResult>>(
                    response, true, "Allocations for Material Batch Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByStatus/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            try
            {
                var query = new GetAllocationsByStatusQuery { Status = status };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllocationsByStatusQueryResult>>(
                    response, true, "Allocations by Status Retrieved Successfully", 200);
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
                var query = new GetAllocationByIdQuery { Id = id };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetAllocationByIdQueryResult?>(
                    response, true, "Allocation Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAllocation([FromBody] CreateAllocationCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<int>(
                    response, true, "Allocation Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> UpdateAllocationStatus([FromBody] UpdateAllocationStatusCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Allocation Status Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateQuantity")]
        public async Task<IActionResult> UpdateAllocationQuantity([FromBody] UpdateAllocationQuantityCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Allocation Quantity Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAllocation([FromQuery] string allocationId)
        {
            try
            {
                if (!int.TryParse(allocationId, out int allocationint))
                    return BadRequest("Invalid Allocation ID.");

                var command = new DeleteAllocationCommand { Id = allocationint };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Allocation Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("MarkAsPicked/{id}")]
        public async Task<IActionResult> MarkAsPicked(int id)
        {
            try
            {
                var command = new UpdateAllocationStatusCommand { Id = id, Status = "picked" };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Allocation Marked as Picked Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("MarkAsShipped/{id}")]
        public async Task<IActionResult> MarkAsShipped(int id)
        {
            try
            {
                var command = new UpdateAllocationStatusCommand { Id = id, Status = "shipped" };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Allocation Marked as Shipped Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Release/{id}")]
        public async Task<IActionResult> ReleaseAllocation(int id)
        {
            try
            {
                var command = new UpdateAllocationStatusCommand { Id = id, Status = "released" };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Allocation Released Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Cancel/{id}")]
        public async Task<IActionResult> CancelAllocation(int id)
        {
            try
            {
                var command = new UpdateAllocationStatusCommand { Id = id, Status = "cancelled" };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Allocation Cancelled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetTotalAllocatedByProduct/{productId}")]
        public async Task<IActionResult> GetTotalAllocatedByProduct(int productId)
        {
            try
            {
                // Note: This endpoint requires an additional query/handler or you can add a method to the repository
                // For now, we'll implement a simple approach
                var allocations = await _mediator.Send(new GetAllocationsByProductIdQuery { ProductId = productId });
                var totalAllocated = allocations
                    .Where(a => a.Status == "allocated" || a.Status == "picked")
                    .Sum(a => a.Quantity);

                var successApiResponse = new SuccessAPIResponse<decimal>(
                    totalAllocated, true, "Total Allocated Quantity for Product Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetTotalAllocatedByMaterialBatch/{materialBatchId}")]
        public async Task<IActionResult> GetTotalAllocatedByMaterialBatch(int materialBatchId)
        {
            try
            {
                // Note: This endpoint requires an additional query/handler or you can add a method to the repository
                var allocations = await _mediator.Send(new GetAllocationsByMaterialBatchIdQuery { MaterialBatchId = materialBatchId });
                var totalAllocated = allocations
                    .Where(a => a.Status == "allocated" || a.Status == "picked")
                    .Sum(a => a.Quantity);

                var successApiResponse = new SuccessAPIResponse<decimal>(
                    totalAllocated, true, "Total Allocated Quantity for Material Batch Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
