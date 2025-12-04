using Inventory.Application.Features.Aisle.Commands.CreateAisleCommand;
using Inventory.Application.Features.Aisle.Commands.DeleteAisleCommand;
using Inventory.Application.Features.Aisle.Commands.UpdateAisleCommand;
using Inventory.Application.Features.Aisle.Queries.GetAislesByWarehouseIdQuery;
using Inventory.Application.Features.Aisle.Queries.GetAislesQuery;
using Inventory.Logging.Interfaces;
using Inventory.Logging.Models;
using Inventory.SuperAdmin.API.Interface;
using Inventory.SuperAdmin.API.Response;
using Inventory.SuperAdmin.API.Response.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AisleController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogWriter _logWriter;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IConfiguration _configuration;

        public AisleController(IMediator mediator, ILogWriter logWriter, IRedisCacheService redisCacheService,
            IConfiguration configuration)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logWriter = logWriter;
            _redisCacheService = redisCacheService;
            _configuration = configuration;
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var cacheKey = HttpContext.Request.Path.ToString();
                _logWriter.WriteLog(LogLevels.Info, "Requested to get all Aisles");
                //var cachedResponse = await _redisCacheService.GetAsync<SuccessAPIResponse<IEnumerable<GetAislesQueryResult>>>(cacheKey);

                //if (cachedResponse != null)
                //{
                //    _logWriter.WriteLog(LogLevels.Info, "All Aisles retrieved successfully");
                //    return Ok(cachedResponse);
                //}

                var response = await _mediator.Send(new GetAislesQuery());

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAislesQueryResult>>(response, true, "All Aisles Retrieved Successfully", 200);

                //double timespanduration = Double.Parse(_configuration["RedisCacheSettings:TimeDuration"]!.ToString());
                //await _redisCacheService.SetAsync(cacheKey, successApiResponse, TimeSpan.FromMinutes(timespanduration));
                _logWriter.WriteLog(LogLevels.Info, "All areas retrieved successfully");

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByWarehouse")]
        public async Task<IActionResult> GetByWarehouseId([FromQuery] string warehouseId)
        {
            try
            {
                if (!int.TryParse(warehouseId, out int warehouseIdint))
                {
                    return BadRequest("Invalid Warehouse ID.");
                }

                var response = await _mediator.Send(new GetAislesByWarehouseIdQuery() { WarehouseId = warehouseIdint });

                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetAislesByWarehouseIdQueryResult>>(response, true, "Aisles by Warehouse Retrieved Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAisle([FromBody] CreateAisleCommand aisle)
        {
            try
            {
                if (aisle is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(aisle);

                var successApiResponse = new SuccessAPIResponse<int>(response, true, "Aisle Created Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAisle([FromBody] UpdateAisleCommand aisle)
        {
            try
            {
                if (aisle is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(aisle);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Aisle Updated Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAisle([FromQuery] string aisleId)
        {
            try
            {
                if (aisleId is null)
                    throw new ArgumentException("A non-empty request body is required.");

                if (!int.TryParse(aisleId, out int aisleint))
                {
                    return BadRequest("Invalid Aisle ID.");
                }

                var command = new DeleteAisleCommand
                {
                    Id = aisleint
                };

                var response = await _mediator.Send(command);

                var successApiResponse = new SuccessAPIResponse<string>("", true, "Aisle Deleted Successfully", 200);

                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
