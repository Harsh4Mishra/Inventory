using Inventory.Application.Features.WarehouseItem.Command.AddWarehouseItemQuantityCommand;
using Inventory.Application.Features.WarehouseItem.Command.CreateWarehouseItemCommand;
using Inventory.Application.Features.WarehouseItem.Command.DeleteWarehouseItemCommand;
using Inventory.Application.Features.WarehouseItem.Command.RemoveWarehouseItemQuantityCommand;
using Inventory.Application.Features.WarehouseItem.Command.UpdateWarehouseItemLocationCommand;
using Inventory.Application.Features.WarehouseItem.Command.UpdateWarehouseItemQuantityCommand;
using Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemByIdQuery;
using Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByLocationQuery;
using Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByMaterialBatchQuery;
using Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsByWarehouseQuery;
using Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsQuery;
using Inventory.Application.Features.WarehouseItem.Queries.GetWarehouseItemsWithLowStockQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseItemController : Controller
    {
        private readonly IMediator _mediator;
        public WarehouseItemController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetWarehouseItemsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetWarehouseItemsQueryResult>>(
                    response, true, "All Warehouse Items Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByWarehouse/{warehouseId}")]
        public async Task<IActionResult> GetByWarehouse(int warehouseId)
        {
            try
            {
                var query = new GetWarehouseItemsByWarehouseQuery { WarehouseId = warehouseId };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetWarehouseItemsByWarehouseQueryResult>>(
                    response, true, "Warehouse Items Retrieved Successfully", 200);
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
                var query = new GetWarehouseItemsByMaterialBatchQuery { MaterialBatchId = materialBatchId };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetWarehouseItemsByMaterialBatchQueryResult>>(
                    response, true, "Warehouse Items Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByLocation")]
        public async Task<IActionResult> GetByLocation([FromQuery] int warehouseId, [FromQuery] int aisleId, [FromQuery] int rowId, [FromQuery] int trayId)
        {
            try
            {
                var query = new GetWarehouseItemsByLocationQuery
                {
                    WarehouseId = warehouseId,
                    AisleId = aisleId,
                    RowId = rowId,
                    TrayId = trayId
                };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetWarehouseItemsByLocationQueryResult>>(
                    response, true, "Warehouse Items Retrieved Successfully", 200);
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
                var query = new GetWarehouseItemByIdQuery { Id = id };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetWarehouseItemByIdQueryResult?>(
                    response, true, "Warehouse Item Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetLowStock")]
        public async Task<IActionResult> GetLowStock([FromQuery] decimal threshold = 10)
        {
            try
            {
                var query = new GetWarehouseItemsWithLowStockQuery { Threshold = threshold };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetWarehouseItemsWithLowStockQueryResult>>(
                    response, true, "Low Stock Warehouse Items Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddWarehouseItem([FromBody] CreateWarehouseItemCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<int>(
                    response, true, "Warehouse Item Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateQuantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateWarehouseItemQuantityCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Warehouse Item Quantity Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("AddQuantity")]
        public async Task<IActionResult> AddQuantity([FromBody] AddWarehouseItemQuantityCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Quantity Added Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("RemoveQuantity")]
        public async Task<IActionResult> RemoveQuantity([FromBody] RemoveWarehouseItemQuantityCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Quantity Removed Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateLocation")]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateWarehouseItemLocationCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Warehouse Item Location Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteWarehouseItem([FromQuery] string warehouseItemId)
        {
            try
            {
                if (!int.TryParse(warehouseItemId, out int warehouseItemint))
                    return BadRequest("Invalid Warehouse Item ID.");

                var command = new DeleteWarehouseItemCommand { Id = warehouseItemint };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Warehouse Item Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
