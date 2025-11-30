using Inventory.Application.Features.InventoryTransaction.Commands.CreateInventoryTransactionCommand;
using Inventory.Application.Features.InventoryTransaction.Commands.DeleteInventoryTransactionCommand;
using Inventory.Application.Features.InventoryTransaction.Commands.UpdateInventoryTransactionCommand;
using Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionByUUIDQuery;
using Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByDateRangeQuery;
using Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByMaterialBatchQuery;
using Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByProductQuery;
using Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsByTypeQuery;
using Inventory.Application.Features.InventoryTransaction.Queries.GetInventoryTransactionsQuery;
using Inventory.Application.Features.InventoryTransaction.Queries.GetStockLevelQuery;
using Inventory.SuperAdmin.API.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.SuperAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryTransactionController : Controller
    {
        private readonly IMediator _mediator;

        public InventoryTransactionController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetInventoryTransactionsQuery());
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetInventoryTransactionsQueryResult>>(
                    response, true, "All Inventory Transactions Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByMaterialBatch/{materialBatchId}")]
        public async Task<IActionResult> GetByMaterialBatch(Guid materialBatchId)
        {
            try
            {
                var query = new GetInventoryTransactionsByMaterialBatchQuery { MaterialBatchId = materialBatchId };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetInventoryTransactionsByMaterialBatchQueryResult>>(
                    response, true, "Inventory Transactions for Material Batch Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByProduct/{productId}")]
        public async Task<IActionResult> GetByProduct(Guid productId)
        {
            try
            {
                var query = new GetInventoryTransactionsByProductQuery { ProductId = productId };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetInventoryTransactionsByProductQueryResult>>(
                    response, true, "Inventory Transactions for Product Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByDateRange")]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var query = new GetInventoryTransactionsByDateRangeQuery
                {
                    StartDate = startDate,
                    EndDate = endDate
                };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetInventoryTransactionsByDateRangeQueryResult>>(
                    response, true, "Inventory Transactions for Date Range Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByUUID/{uuid}")]
        public async Task<IActionResult> GetByUUID(Guid uuid)
        {
            try
            {
                var query = new GetInventoryTransactionByUUIDQuery { UUID = uuid };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<GetInventoryTransactionByUUIDQueryResult?>(
                    response, true, "Inventory Transaction Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetByType/{transactionType}")]
        public async Task<IActionResult> GetByType(string transactionType)
        {
            try
            {
                var query = new GetInventoryTransactionsByTypeQuery { TransactionType = transactionType };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<IEnumerable<GetInventoryTransactionsByTypeQueryResult>>(
                    response, true, "Inventory Transactions by Type Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetStockLevel")]
        public async Task<IActionResult> GetStockLevel([FromQuery] Guid? materialBatchId, [FromQuery] Guid? productId)
        {
            try
            {
                var query = new GetStockLevelQuery
                {
                    MaterialBatchId = materialBatchId,
                    ProductId = productId
                };
                var response = await _mediator.Send(query);
                var successApiResponse = new SuccessAPIResponse<decimal>(
                    response, true, "Current Stock Level Retrieved Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateInventoryTransactionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "Inventory Transaction Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTransaction([FromBody] UpdateInventoryTransactionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Inventory Transaction Updated Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTransaction(Guid id)
        {
            try
            {
                //if (id <= 0)
                //    return BadRequest("Invalid Transaction ID.");

                var command = new DeleteInventoryTransactionCommand { Id = id };
                await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<string>(
                    "", true, "Inventory Transaction Deleted Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Receive")]
        public async Task<IActionResult> CreateReceiveTransaction([FromBody] CreateInventoryTransactionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                command.TransactionType = "receive";
                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "Receive Transaction Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Issue")]
        public async Task<IActionResult> CreateIssueTransaction([FromBody] CreateInventoryTransactionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                command.TransactionType = "issue";
                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "Issue Transaction Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Transfer")]
        public async Task<IActionResult> CreateTransferTransaction([FromBody] CreateInventoryTransactionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                command.TransactionType = "transfer";
                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "Transfer Transaction Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Adjust")]
        public async Task<IActionResult> CreateAdjustmentTransaction([FromBody] CreateInventoryTransactionCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentException("A non-empty request body is required.");

                command.TransactionType = "adjust";
                var response = await _mediator.Send(command);
                var successApiResponse = new SuccessAPIResponse<Guid>(
                    response, true, "Adjustment Transaction Created Successfully", 200);
                return Ok(successApiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
