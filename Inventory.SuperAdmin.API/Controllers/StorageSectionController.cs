using Inventory.Application.Features.StorageSection.Command.CreateStorageSectionCommand;
using Inventory.Application.Features.StorageSection.Command.DeleteStorageSectionCommand;
using Inventory.Application.Features.StorageSection.Command.ToggleStorageSectionStatusCommand;
using Inventory.Application.Features.StorageSection.Command.UpdateStorageSectionCommand;
using Inventory.Application.Features.StorageSection.Queries.GetActiveStorageSectionsQuery;
using Inventory.Application.Features.StorageSection.Queries.GetStorageSectionByIdQuery;
using Inventory.Application.Features.StorageSection.Queries.GetStorageSectionByNameQuery;
using Inventory.Application.Features.StorageSection.Queries.GetStorageSectionsQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageSectionController : Controller
    {
        private readonly IMediator _mediator;
        public StorageSectionController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetStorageSectionsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetStorageSectionsQueryResult>>(
                    response, true, "All Storage Sections Retrieved Successfully", 200);
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
                var response = await _mediator.Send(new GetActiveStorageSectionsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetActiveStorageSectionsQueryResult>>(
                    response, true, "All Active Storage Sections Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var response = await _mediator.Send(new GetStorageSectionByIdQuery { Id = id });
                var successApiResponse = new SuccessAPIResponse<GetStorageSectionByIdQueryResult?>(
                    response, true, "Storage Section Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var response = await _mediator.Send(new GetStorageSectionByNameQuery { Name = name });
                var successApiResponse = new SuccessAPIResponse<GetStorageSectionByNameQueryResult?>(
                    response, true, "Storage Section Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddStorageSection([FromBody] CreateStorageSectionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "Storage Section Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateStorageSection([FromBody] UpdateStorageSectionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Storage Section Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteStorageSection([FromQuery] string storageSectionId)
        {
            try
            {
                if (!Guid.TryParse(storageSectionId, out Guid storageSectionGuid))
                    return BadRequest("Invalid Storage Section ID.");

                var command = new DeleteStorageSectionCommand { Id = storageSectionGuid };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Storage Section Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Toggle")]
        public async Task<IActionResult> ToggleStorageSection([FromQuery] ToggleStorageSectionStatusCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Storage Section Status Toggled Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
