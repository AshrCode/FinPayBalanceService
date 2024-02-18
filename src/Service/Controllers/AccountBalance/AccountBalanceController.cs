using Application.AccountBalance;
using Common.ApiException;
using Microsoft.AspNetCore.Mvc;
using Service.Responses;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers.AccountBalance
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountBalanceController : BaseController
    {
        private readonly IAccountBalanceApp _accountBalanceApp;

        public AccountBalanceController(ILogger<AccountBalanceController> logger, IAccountBalanceApp accountBalanceApp)
            : base(logger)
        {
            _accountBalanceApp = accountBalanceApp;
        }

        // <summary>
        /// Gets the account balance of the specified user.
        /// </summary>
        // GET: api/<BalanceController>/B136CF3D-766B-45AE-AA84-AC7F10C5A090
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid userId)
        {
            try
            {
                var result = await _accountBalanceApp.GetAsync(userId);

                ApiResponse response = new()
                {
                    ErrorCode = HttpStatusCode.OK,
                    Data = result
                };

                return Ok(response);
            }
            catch (ApiException aexp)
            {
                return HandleApiException(aexp);
            }
            catch (Exception ex)
            {
                return HandleApiException(ex);
            }
        }

        // PUT api/<BalanceController>/5
        [HttpPut("DebitAmount/{userId}")]
        public async Task<IActionResult> DebitAmount(Guid userId, [FromBody] float amountToDebit)
        {
            try
            {
                var result = await _accountBalanceApp.DebitAmount(userId, amountToDebit);

                ApiResponse response = new()
                {
                    ErrorCode = HttpStatusCode.OK,
                    Data = result
                };

                return Ok(response);
            }
            catch (ApiException aexp)
            {
                return HandleApiException(aexp);
            }
            catch (Exception ex)
            {
                return HandleApiException(ex);
            }
        }
    }
}
