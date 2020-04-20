using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SenderConsumer.Common.Domain.Withdrawals;

namespace SenderConsumer.WebApi
{
    [ApiController]
    [Route("api/withdrawals")]
    public class WithdrawalsController : ControllerBase
    {
        private readonly ISendEndpointProvider _commandsSender;

        public WithdrawalsController(ISendEndpointProvider commandsSender)
        {
            _commandsSender = commandsSender;
        }

        [HttpPost("execute")]
        public async Task<IActionResult> ExecuteWithdrawal([FromBody] ExecuteWithdrawal request)
        {
            await _commandsSender.Send(new ExecuteWithdrawal
            {
                Id = request.Id
            });

            return Ok();
        }
    }
}
