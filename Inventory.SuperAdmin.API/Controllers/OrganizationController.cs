using Inventory.Application.Features.Organization.Commands.CreateOrganizationCommand;
using Inventory.Application.Features.Organization.Commands.DeleteOrganizationCommand;
using Inventory.Application.Features.Organization.Commands.ToggleOrganizationStatusCommand;
using Inventory.Application.Features.Organization.Commands.UpdateOrganizationCommand;
using Inventory.Application.Features.Organization.Queries.GetActiveOrganizationQuery;
using Inventory.Application.Features.Organization.Queries.GetOrganizationQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : Controller
    {
        private readonly IMediator _mediator;
        public OrganizationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetOrganizationQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetOrganizationQueryResult>>(
                    response, true, "All Organizations Retrieved Successfully", 200);
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
                var response = await _mediator.Send(new GetActiveOrganizationQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveOrganizationQueryResult>>(
                    response, true, "All Active Organizations Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddOrganization([FromBody] CreateOrganizationCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "Organization Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateOrganization([FromBody] UpdateOrganizationCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Organization Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteOrganization([FromQuery] string organizationId)
        {
            try
            {
                if (!Guid.TryParse(organizationId, out Guid organizationGuid))
                    return BadRequest("Invalid Organization ID.");

                var command = new DeleteOrganizationCommand { Id = organizationGuid };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Organization Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> ToggleOrganization([FromQuery] ToggleOrganizationStatusCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Organization Status Toggled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
