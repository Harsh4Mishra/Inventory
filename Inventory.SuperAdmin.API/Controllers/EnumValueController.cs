using Inventory.Application.Features.EnumValue.Commands.CreateEnumValueCommand;
using Inventory.Application.Features.EnumValue.Commands.DeleteEnumValueCommand;
using Inventory.Application.Features.EnumValue.Commands.ToggleEnumValueStatusCommand;
using Inventory.Application.Features.EnumValue.Commands.UpdateEnumValueCommand;
using Inventory.Application.Features.EnumValue.Queries.GetActiveEnumValuesByEnumTypeIdQuery;
using Inventory.Application.Features.EnumValue.Queries.GetEnumValuesByEnumTypeIdQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumValueController : Controller
    {
        private readonly IMediator _mediator;

        public EnumValueController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllByEnumTypeId([FromQuery] string enumTypeId)
        {
            try
            {
                int? enumTypeIdint = null;
                if (!string.IsNullOrEmpty(enumTypeId) && int.TryParse(enumTypeId, out int parsedint))
                {
                    enumTypeIdint = parsedint;
                }
                else
                {
                    return BadRequest("Invalid Enum Type ID.");
                }

                var response = await _mediator.Send(new GetEnumValuesByEnumTypeIdQuery() { EnumTypeId = (int)enumTypeIdint });

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetEnumValuesByEnumTypeIdQueryResult>>(response, true, "Enum Values Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetActive")]
        public async Task<IActionResult> GetActiveByEnumTypeId([FromQuery] string enumTypeId)
        {
            try
            {
                int? enumTypeIdint = null;
                if (!string.IsNullOrEmpty(enumTypeId) && int.TryParse(enumTypeId, out int parsedint))
                {
                    enumTypeIdint = parsedint;
                }
                else
                {
                    return BadRequest("Invalid Enum Type ID.");
                }

                var response = await _mediator.Send(new GetActiveEnumValuesByEnumTypeIdQuery() { EnumTypeId = (int)enumTypeIdint });

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveEnumValuesByEnumTypeIdQueryResult>>(response, true, "Active Enum Values Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddEnumValue([FromBody] CreateEnumValueCommand enumValue)
        {
            try
            {
                if (enumValue is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(enumValue);

                var successApiResponse = new SuccessAPIResponse<int>(response, true, "Enum Value Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEnumValue([FromBody] UpdateEnumValueCommand enumValue)
        {
            try
            {
                if (enumValue is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(enumValue);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Enum Value Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEnumValue([FromQuery] string enumValueId, string enumTypeId)
        {
            try
            {
                if (enumValueId is null)
                    throw new ArgumentException("Enum Value ID is required.");

                if (!int.TryParse(enumValueId, out int enumValueint))
                {
                    return BadRequest("Invalid Enum Value ID.");
                }

                if (enumTypeId is null)
                    throw new ArgumentException("Enum Type ID is required.");

                if (!int.TryParse(enumTypeId, out int enumTypeint))
                {
                    return BadRequest("Invalid Enum Type ID.");
                }

                var command = new DeleteEnumValueCommand
                {
                    Id = enumValueint,
                    EnumTypeId = enumTypeint
                };

                var response = await _mediator.Send(command);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Enum Value Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> ToggleEnumValue([FromBody] ToggleEnumValueStatusCommand enumValue)
        {
            try
            {
                if (enumValue is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(enumValue);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Enum Value Status Toggled Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
