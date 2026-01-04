using Inventory.Application.Features.User.Commands.CreateUserCommand;
using Inventory.Application.Features.User.Commands.DeleteUserCommand;
using Inventory.Application.Features.User.Commands.ToggleUserStatusCommand;
using Inventory.Application.Features.User.Commands.UpdateUserCommand;
using Inventory.Application.Features.User.Queries.GetActiveUsersQuery;
using Inventory.Application.Features.User.Queries.GetUsersQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        #region Query Endpoints

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetUsersQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetUsersQueryResult>>(
                    response,
                    true,
                    "All users retrieved successfully",
                    200);
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
                var response = await _mediator.Send(new GetActiveUsersQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveUsersQueryResult>>(
                    response,
                    true,
                    "All active users retrieved successfully",
                    200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Command Endpoints

        [HttpPost("Add")]
        public async Task<IActionResult> AddUser([FromBody] CreateUserCommand user)
        {
            try
            {
                if (user is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(user);
                var successApiResponse = new SuccessAPIResponse<int>(
                    response,
                    true,
                    "User created successfully",
                    200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand user)
        {
            try
            {
                if (user is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(user);
                var successApiResponse = new SuccessAPIResponse<string>(
                    string.Empty,
                    true,
                    "User updated successfully",
                    200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUser([FromQuery] string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                    throw new ArgumentException("User ID is required.");

                if (!int.TryParse(userId, out int userint))
                    return BadRequest("Invalid User ID format.");

                var command = new DeleteUserCommand { Id = userint };
                await _mediator.Send(command);

                var successApiResponse = new SuccessAPIResponse<string>(
                    string.Empty,
                    true,
                    "User deleted successfully",
                    200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("ToggleStatus")]
        public async Task<IActionResult> ToggleUserStatus([FromBody] ToggleUserStatusCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    string.Empty,
                    true,
                    "User status toggled successfully",
                    200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
