using Inventory.Application.Features.MaterialStorageRule.Commands.CreateMaterialStorageRuleCommand;
using Inventory.Application.Features.MaterialStorageRule.Commands.DeleteMaterialStorageRuleCommand;
using Inventory.Application.Features.MaterialStorageRule.Commands.UpdateMaterialStorageRuleCommand;
using Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRuleByIdQuery;
using Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRuleByMaterialIdQuery;
using Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRulesByPreferredSectionQuery;
using Inventory.Application.Features.MaterialStorageRule.Queries.GetMaterialStorageRulesQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialStorageRuleController : Controller
    {
        private readonly IMediator _mediator;
        public MaterialStorageRuleController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetMaterialStorageRulesQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetMaterialStorageRulesQueryResult>>(
                    response, true, "All Material Storage Rules Retrieved Successfully", 200);
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
                var query = new GetMaterialStorageRuleByIdQuery { Id = id };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetMaterialStorageRuleByIdQueryResult?>(
                    response, true, "Material Storage Rule Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByMaterialId/{materialId}")]
        public async Task<IActionResult> GetByMaterialId(Guid materialId)
        {
            try
            {
                var query = new GetMaterialStorageRuleByMaterialIdQuery { MaterialId = materialId };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetMaterialStorageRuleByMaterialIdQueryResult?>(
                    response, true, "Material Storage Rule Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByPreferredSection/{preferredSectionId}")]
        public async Task<IActionResult> GetByPreferredSection(Guid preferredSectionId)
        {
            try
            {
                var query = new GetMaterialStorageRulesByPreferredSectionQuery { PreferredSectionId = preferredSectionId };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetMaterialStorageRulesByPreferredSectionQueryResult>>(
                    response, true, "Material Storage Rules Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddMaterialStorageRule([FromBody] CreateMaterialStorageRuleCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "Material Storage Rule Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateMaterialStorageRule([FromBody] UpdateMaterialStorageRuleCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Material Storage Rule Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteMaterialStorageRule([FromQuery] string materialStorageRuleId)
        {
            try
            {
                if (!Guid.TryParse(materialStorageRuleId, out Guid materialStorageRuleGuid))
                    return BadRequest("Invalid Material Storage Rule ID.");

                var command = new DeleteMaterialStorageRuleCommand { Id = materialStorageRuleGuid };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Material Storage Rule Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
