using Inventory.Application.Features.Role.Commands.CreateRoleCommand;
using Inventory.Application.Features.Role.Commands.DeleteRoleCommand;
using Inventory.Application.Features.Role.Commands.ToggleRoleStatusCommand;
using Inventory.Application.Features.Role.Commands.UpdateRoleCommand;
using Inventory.Application.Features.Role.Queries.GetActiveRolesQuery;
using Inventory.Application.Features.Role.Queries.GetRolesQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetRolesQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetRolesQueryResult>>(
                    response, true, "All Roles Retrieved Successfully", 200);
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
                var response = await _mediator.Send(new GetActiveRolesQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveRolesQueryResult>>(
                    response, true, "All Active Roles Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddRole([FromBody] CreateRoleCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "Role Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Role Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteRole([FromQuery] string roleId)
        {
            try
            {
                if (!Guid.TryParse(roleId, out Guid roleGuid))
                    return BadRequest("Invalid Role ID.");

                var command = new DeleteRoleCommand { Id = roleGuid };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Role Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> ToggleRole([FromQuery] ToggleRoleStatusCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Role Status Toggled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
