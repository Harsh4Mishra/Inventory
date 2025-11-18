using Inventory.Application.Features.Vendor.Commands.CreateVendorCommand;
using Inventory.Application.Features.Vendor.Commands.DeleteVendorCommand;
using Inventory.Application.Features.Vendor.Commands.ToggleVendorStatusCommand;
using Inventory.Application.Features.Vendor.Commands.UpdateVendorCommand;
using Inventory.Application.Features.Vendor.Queries.GetActiveVendorsQuery;
using Inventory.Application.Features.Vendor.Queries.GetVendorByIdQuery;
using Inventory.Application.Features.Vendor.Queries.GetVendorsQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : Controller
    {
        private readonly IMediator _mediator;
        public VendorController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetVendorsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetVendorsQueryResult>>(
                    response, true, "All Vendors Retrieved Successfully", 200);
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
                var response = await _mediator.Send(new GetActiveVendorsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveVendorsQueryResult>>(
                    response, true, "All Active Vendors Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string vendorId)
        {
            try
            {
                if (!Guid.TryParse(vendorId, out Guid vendorGuid))
                    return BadRequest("Invalid Vendor ID.");

                var query = new GetVendorByIdQuery { Id = vendorGuid };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetVendorByIdQueryResult>(
                    response, true, "Vendor Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddVendor([FromBody] CreateVendorCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "Vendor Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateVendor([FromBody] UpdateVendorCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Vendor Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteVendor([FromQuery] string vendorId)
        {
            try
            {
                if (!Guid.TryParse(vendorId, out Guid vendorGuid))
                    return BadRequest("Invalid Vendor ID.");

                var command = new DeleteVendorCommand { Id = vendorGuid };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Vendor Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> ToggleVendor([FromQuery] ToggleVendorStatusCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Vendor Status Toggled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
