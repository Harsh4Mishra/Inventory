using Inventory.Application.Features.EnumType.Commands.CreateEnumTypeCommand;
using Inventory.Application.Features.EnumType.Commands.DeleteEnumTypeCommand;
using Inventory.Application.Features.EnumType.Commands.ToggleEnumTypeStatusCommand;
using Inventory.Application.Features.EnumType.Commands.UpdateEnumTypeCommand;
using Inventory.Application.Features.EnumType.Queries.GetActiveEnumTypesQuery;
using Inventory.Application.Features.EnumType.Queries.GetAllEnumTypeQuery;
using Inventory.Application.Features.EnumType.Queries.GetEnumTypeByIdQuery;
using Inventory.Application.Features.EnumType.Queries.GetEnumTypeByNameQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumTypeController : Controller
    {
        private readonly IMediator _mediator;
        public EnumTypeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllEnumTypesQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAllEnumTypesQueryResult>>(response, true, "All Enum Types Retrieved Successfully", 200);

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
                var response = await _mediator.Send(new GetActiveEnumTypesQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveEnumTypesQueryResult>>(response, true, "All Active Enum Types Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string enumTypeId)
        {
            try
            {
                if (!int.TryParse(enumTypeId, out int enumTypeint))
                {
                    return BadRequest("Invalid Enum Type ID.");
                }

                var response = await _mediator.Send(new GetEnumTypeByIdQuery { Id = enumTypeint });

                var successApiResponse = new SuccessAPIResponse<GetEnumTypeByIdQueryResult>(response, true, "Enum Type Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest("Name is required.");
                }

                var response = await _mediator.Send(new GetEnumTypeByNameQuery { Name = name });

                var successApiResponse = new SuccessAPIResponse<GetEnumTypeByNameQueryResult>(response, true, "Enum Type Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddEnumType([FromBody] CreateEnumTypeCommand enumType)
        {
            try
            {
                if (enumType is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(enumType);

                var successApiResponse = new SuccessAPIResponse<int>(response, true, "Enum Type Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEnumType([FromBody] UpdateEnumTypeCommand enumType)
        {
            try
            {
                if (enumType is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(enumType);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Enum Type Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEnumType([FromQuery] string enumTypeId)
        {
            try
            {
                if (enumTypeId is null)
                    throw new ArgumentException("A non-empty request body is required.");

                if (!int.TryParse(enumTypeId, out int enumTypeint))
                {
                    return BadRequest("Invalid Enum Type ID.");
                }

                var command = new DeleteEnumTypeCommand
                {
                    Id = enumTypeint
                };

                var response = await _mediator.Send(command);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Enum Type Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> ToggleEnumType([FromBody] ToggleEnumTypeStatusCommand enumType)
        {
            try
            {
                if (enumType is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(enumType);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Enum Type Status Toggled Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
