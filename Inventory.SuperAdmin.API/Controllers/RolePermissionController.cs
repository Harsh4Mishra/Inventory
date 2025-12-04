using Inventory.Application.Features.RolePermission.Commands.CreateRolePermissionCommand;
using Inventory.Application.Features.RolePermission.Commands.DeleteRolePermissionCommand;
using Inventory.Application.Features.RolePermission.Commands.ToggleRolePermissionCommand;
using Inventory.Application.Features.RolePermission.Commands.UpdateRolePermissionCommand;
using Inventory.Application.Features.RolePermission.Queries.GetActiveRolePermissionsByPermissionIdQuery;
using Inventory.Application.Features.RolePermission.Queries.GetActiveRolePermissionsByRoleIdQuery;
using Inventory.Application.Features.RolePermission.Queries.GetActiveRolePermissionsByTenantIdQuery;
using Inventory.Application.Features.RolePermission.Queries.GetAllActiveRolePermissionsQuery;
using Inventory.Application.Features.RolePermission.Queries.GetAllRolePermissionsQuery;
using Inventory.Application.Features.RolePermission.Queries.GetRolePermissionByIdQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : Controller
    {
        private readonly IMediator _mediator;
        public RolePermissionController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllRolePermissionsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllRolePermissionsQueryResult>>(
                    response, true, "All Role-Permission Assignments Retrieved Successfully", 200);
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
                var response = await _mediator.Send(new GetAllActiveRolePermissionsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllActiveRolePermissionsQueryResult>>(
                    response, true, "All Active Role-Permission Assignments Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByRoleId/{roleId}")]
        public async Task<IActionResult> GetByRoleId(string roleId)
        {
            try
            {
                if (!int.TryParse(roleId, out int roleint))
                    return BadRequest("Invalid Role ID.");

                var query = new GetActiveRolePermissionsByRoleIdQuery { RoleId = roleint };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveRolePermissionsByRoleIdQueryResult>>(
                    response, true, "Role-Permission Assignments Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByPermissionId/{permissionId}")]
        public async Task<IActionResult> GetByPermissionId(string permissionId)
        {
            try
            {
                if (!int.TryParse(permissionId, out int permissionint))
                    return BadRequest("Invalid Permission ID.");

                var query = new GetActiveRolePermissionsByPermissionIdQuery { PermissionId = permissionint };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveRolePermissionsByPermissionIdQueryResult>>(
                    response, true, "Role-Permission Assignments Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByTenantId/{tenantId}")]
        public async Task<IActionResult> GetByTenantId(string tenantId)
        {
            try
            {
                if (!int.TryParse(tenantId, out int tenantint))
                    return BadRequest("Invalid Tenant ID.");

                var query = new GetActiveRolePermissionsByTenantIdQuery { TenantId = tenantint };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveRolePermissionsByTenantIdQueryResult>>(
                    response, true, "Role-Permission Assignments Retrieved Successfully", 200);
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
                if (!int.TryParse(id, out int assignmentint))
                    return BadRequest("Invalid Role-Permission Assignment ID.");

                var query = new GetRolePermissionByIdQuery { Id = assignmentint };
                var response = await _mediator.Send(query);

                if (response == null)
                {
                    return BadRequest("Role-Permission Assignment not found");
                }

                var successApiResponse = new SuccessAPIResponse<GetRolePermissionByIdQueryResult>(
                    response, true, "Role-Permission Assignment Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Assign")]
        public async Task<IActionResult> AssignRolePermission([FromBody] CreateRolePermissionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<int>(
                    response, true, "Role-Permission Assignment Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateRolePermission([FromBody] UpdateRolePermissionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Role-Permission Assignment Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> RemoveRolePermission([FromQuery] string assignmentId)
        {
            try
            {
                if (!int.TryParse(assignmentId, out int assignmentint))
                    return BadRequest("Invalid Role-Permission Assignment ID.");

                var command = new DeleteRolePermissionCommand { Id = assignmentint };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Role-Permission Assignment Removed Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> ToggleRolePermission([FromQuery] ToggleRolePermissionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Role-Permission Assignment Status Toggled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("BulkAssign")]
        public async Task<IActionResult> BulkAssignRolePermissions([FromBody] List<CreateRolePermissionCommand> commands)
        {
            try
            {
                if (commands is null || !commands.Any())
                    throw new ArgumentException("A non-empty request body is required.");

                var results = new List<int>();
                foreach (var command in commands)
                {
                    var result = await _mediator.Send(command);
                    results.Add(result);
                }

                var successApiResponse = new SuccessAPIResponse<List<int>>(
                    results, true, "Role-Permission Assignments Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
