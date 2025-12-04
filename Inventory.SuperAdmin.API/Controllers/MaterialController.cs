using Inventory.Application.Features.Material.Commands.CreateMaterialCommand;
using Inventory.Application.Features.Material.Commands.DeleteMaterialCommand;
using Inventory.Application.Features.Material.Commands.ToggleMaterialStatusCommand;
using Inventory.Application.Features.Material.Commands.UpdateMaterialCommand;
using Inventory.Application.Features.Material.Commands.UpdateMaterialSkuCommand;
using Inventory.Application.Features.Material.Queries.GetActiveMaterialsQuery;
using Inventory.Application.Features.Material.Queries.GetMaterialByIdQuery;
using Inventory.Application.Features.Material.Queries.GetMaterialBySkuQuery;
using Inventory.Application.Features.Material.Queries.GetMaterialsQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : Controller
    {
        private readonly IMediator _mediator;
        public MaterialController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetMaterialsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetMaterialsQueryResult>>(
                    response, true, "All Materials Retrieved Successfully", 200);
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
                var response = await _mediator.Send(new GetActiveMaterialsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveMaterialsQueryResult>>(
                    response, true, "All Active Materials Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string materialId)
        {
            try
            {
                if (!int.TryParse(materialId, out int materialint))
                    return BadRequest("Invalid Material ID.");

                var query = new GetMaterialByIdQuery { Id = materialint };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetMaterialByIdQueryResult>(
                    response, true, "Material Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetBySku")]
        public async Task<IActionResult> GetBySku([FromQuery] string sku)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sku))
                    return BadRequest("SKU is required.");

                var query = new GetMaterialBySkuQuery { Sku = sku };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetMaterialBySkuQueryResult>(
                    response, true, "Material Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddMaterial([FromBody] CreateMaterialCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<int>(
                    response, true, "Material Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateMaterial([FromBody] UpdateMaterialCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Material Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateSku")]
        public async Task<IActionResult> UpdateMaterialSku([FromBody] UpdateMaterialSkuCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Material SKU Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteMaterial([FromQuery] string materialId)
        {
            try
            {
                if (!int.TryParse(materialId, out int materialint))
                    return BadRequest("Invalid Material ID.");

                var command = new DeleteMaterialCommand { Id = materialint };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Material Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> ToggleMaterial([FromQuery] ToggleMaterialStatusCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Material Status Toggled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
