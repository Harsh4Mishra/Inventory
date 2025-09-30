using Inventory.Application.Features.AppModule.Commands.CreateAppModuleCommand;
using Inventory.Application.Features.AppModule.Commands.DeleteAppModuleCommand;
using Inventory.Application.Features.AppModule.Commands.ToggleAppModuleCommand;
using Inventory.Application.Features.AppModule.Commands.UpdateAppModuleCommand;
using Inventory.Application.Features.AppModule.Queries.GetActiveAppModulesByTenantIdQuery;
using Inventory.Application.Features.AppModule.Queries.GetAppModuleByIdQuery;
using Inventory.Application.Features.AppModule.Queries.GetAppModulesByTenantIdQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppModuleController : Controller
    {
        private readonly IMediator _mediator;
        public AppModuleController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet("GetByTenantId/{tenantId}")]
        public async Task<IActionResult> GetByTenantId(string tenantId)
        {
            try
            {
                if (!Guid.TryParse(tenantId, out Guid tenantGuid))
                    return BadRequest("Invalid Tenant ID.");

                var query = new GetAppModulesByTenantIdQuery { TenantId = tenantGuid };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAppModulesByTenantIdQueryResult>>(
                    response, true, "App Modules Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetActiveByTenantId/{tenantId}")]
        public async Task<IActionResult> GetActiveByTenantId(string tenantId)
        {
            try
            {
                if (!Guid.TryParse(tenantId, out Guid tenantGuid))
                    return BadRequest("Invalid Tenant ID.");

                var query = new GetActiveAppModulesByTenantIdQuery { TenantId = tenantGuid };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveAppModulesByTenantIdQueryResult>>(
                    response, true, "Active App Modules Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid moduleGuid))
                    return BadRequest("Invalid App Module ID.");

                var query = new GetAppModuleByIdQuery { Id = moduleGuid };
                var response = await _mediator.Send(query);

                if (response == null)
                {
                    return BadRequest("App Module not found");
                }

                var successApiResponse = new SuccessAPIResponse<GetAppModuleByIdQueryResult>(
                    response, true, "App Module Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAppModule([FromBody] CreateAppModuleCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "App Module Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAppModule([FromBody] UpdateAppModuleCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "App Module Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAppModule([FromQuery] string moduleId)
        {
            try
            {
                if (!Guid.TryParse(moduleId, out Guid moduleGuid))
                    return BadRequest("Invalid App Module ID.");

                var command = new DeleteAppModuleCommand { Id = moduleGuid };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "App Module Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> ToggleAppModule([FromQuery] ToggleAppModuleCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "App Module Status Toggled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
