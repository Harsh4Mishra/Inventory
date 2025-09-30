using Inventory.Application.Features.Permission.Commands.CreatePermissionCommand;
using Inventory.Application.Features.Permission.Commands.DeletePermissionCommand;
using Inventory.Application.Features.Permission.Commands.TogglePermissionCommand;
using Inventory.Application.Features.Permission.Commands.UpdatePermissionCommand;
using Inventory.Application.Features.Permission.Queries.GetActivePermissionsByTenantIdQuery;
using Inventory.Application.Features.Permission.Queries.GetPermissionByIdQuery;
using Inventory.Application.Features.Permission.Queries.GetPermissionsByTenantIdQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : Controller
    {
        private readonly IMediator _mediator;
        public PermissionController(IMediator mediator)
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

                var query = new GetPermissionsByTenantIdQuery { TenantId = tenantGuid };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetPermissionsByTenantIdQueryResult>>(
                    response, true, "Permissions Retrieved Successfully", 200);
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

                var query = new GetActivePermissionsByTenantIdQuery { TenantId = tenantGuid };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActivePermissionsByTenantIdQueryResult>>(
                    response, true, "Active Permissions Retrieved Successfully", 200);
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
                if (!Guid.TryParse(id, out Guid permissionGuid))
                    return BadRequest("Invalid Permission ID.");

                var query = new GetPermissionByIdQuery { Id = permissionGuid };
                var response = await _mediator.Send(query);

                if (response == null)
                {
                    return BadRequest("Permission not found");
                }

                var successApiResponse = new SuccessAPIResponse<GetPermissionByIdQueryResult>(
                    response, true, "Permission Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddPermission([FromBody] CreatePermissionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "Permission Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdatePermission([FromBody] UpdatePermissionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Permission Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePermission([FromQuery] string permissionId)
        {
            try
            {
                if (!Guid.TryParse(permissionId, out Guid permissionGuid))
                    return BadRequest("Invalid Permission ID.");

                var command = new DeletePermissionCommand { Id = permissionGuid };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Permission Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> TogglePermission([FromQuery] TogglePermissionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Permission Status Toggled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
