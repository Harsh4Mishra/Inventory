using Inventory.Application.Features.Warehouse.Command.CreateWarehouseCommand;
using Inventory.Application.Features.Warehouse.Command.DeleteWarehouseCommand;
using Inventory.Application.Features.Warehouse.Command.ToggleWarehouseStatusCommand;
using Inventory.Application.Features.Warehouse.Command.UpdateWarehouseCommand;
using Inventory.Application.Features.Warehouse.Queries.GetActiveWarehousesQuery;
using Inventory.Application.Features.Warehouse.Queries.GetWarehouseByIdQuery;
using Inventory.Application.Features.Warehouse.Queries.GetWarehouseByNameQuery;
using Inventory.Application.Features.Warehouse.Queries.GetWarehousesQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private readonly IMediator _mediator;
        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetWarehousesQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetWarehousesQueryResult>>(
                    response, true, "All Warehouses Retrieved Successfully", 200);
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
                var response = await _mediator.Send(new GetActiveWarehousesQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveWarehousesQueryResult>>(
                    response, true, "All Active Warehouses Retrieved Successfully", 200);
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
                var response = await _mediator.Send(new GetWarehouseByIdQuery { Id = id });
                var successApiResponse = new SuccessAPIResponse<GetWarehouseByIdQueryResult?>(
                    response, true, "Warehouse Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var response = await _mediator.Send(new GetWarehouseByNameQuery { Name = name });
                var successApiResponse = new SuccessAPIResponse<GetWarehouseByNameQueryResult?>(
                    response, true, "Warehouse Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddWarehouse([FromBody] CreateWarehouseCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<int>(
                    response, true, "Warehouse Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateWarehouse([FromBody] UpdateWarehouseCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Warehouse Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteWarehouse([FromQuery] string warehouseId)
        {
            try
            {
                if (!int.TryParse(warehouseId, out int warehouseint))
                    return BadRequest("Invalid Warehouse ID.");

                var command = new DeleteWarehouseCommand { Id = warehouseint };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Warehouse Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> ToggleWarehouse([FromQuery] ToggleWarehouseStatusCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Warehouse Status Toggled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
