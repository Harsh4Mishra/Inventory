using Inventory.Application.Features.UserRole.Commands.CreateUserRoleCommand;
using Inventory.Application.Features.UserRole.Commands.DeleteUserRoleCommand;
using Inventory.Application.Features.UserRole.Commands.ToggleUserRoleCommand;
using Inventory.Application.Features.UserRole.Commands.UpdateUserRoleCommand;
using Inventory.Application.Features.UserRole.Queries.GetActiveUserRolesQuery;
using Inventory.Application.Features.UserRole.Queries.GetUserRoleByIdQuery;
using Inventory.Application.Features.UserRole.Queries.GetUserRolesByRoleIdQuery;
using Inventory.Application.Features.UserRole.Queries.GetUserRolesByUserIdQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : Controller
    {
        private readonly IMediator _mediator;
        public UserRoleController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetActiveUserRolesQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveUserRolesQueryResult>>(
                    response, true, "All User-Role Assignments Retrieved Successfully", 200);
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
                var response = await _mediator.Send(new GetActiveUserRolesQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveUserRolesQueryResult>>(
                    response, true, "All Active User-Role Assignments Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            try
            {
                if (!int.TryParse(userId, out int userint))
                    return BadRequest("Invalid User ID.");

                var query = new GetUserRolesByUserIdQuery { UserId = userint };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetUserRolesByUserIdQueryResult>>(
                    response, true, "User-Role Assignments Retrieved Successfully", 200);
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

                var query = new GetUserRolesByRoleIdQuery { RoleId = roleint };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetUserRolesByRoleIdQueryResult>>(
                    response, true, "User-Role Assignments Retrieved Successfully", 200);
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
                    return BadRequest("Invalid Assignment ID.");

                var query = new GetUserRoleByIdQuery { Id = assignmentint };
                var response = await _mediator.Send(query);

                if (response == null)
                {
                    return BadRequest("User-Role Assignment not found");
                }

                var successApiResponse = new SuccessAPIResponse<GetUserRoleByIdQueryResult>(
                    response, true, "User-Role Assignment Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Assign")]
        public async Task<IActionResult> AssignUserRole([FromBody] CreateUserRoleCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<int>(
                    response, true, "User-Role Assignment Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "User-Role Assignment Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> RemoveUserRole([FromQuery] string assignmentId)
        {
            try
            {
                if (!int.TryParse(assignmentId, out int assignmentint))
                    return BadRequest("Invalid Assignment ID.");

                var command = new DeleteUserRoleCommand { Id = assignmentint };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "User-Role Assignment Removed Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> ToggleUserRole([FromQuery] ToggleUserRoleCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "User-Role Assignment Status Toggled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("BulkAssign")]
        public async Task<IActionResult> BulkAssignUserRoles([FromBody] List<CreateUserRoleCommand> commands)
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
                    results, true, "User-Role Assignments Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
