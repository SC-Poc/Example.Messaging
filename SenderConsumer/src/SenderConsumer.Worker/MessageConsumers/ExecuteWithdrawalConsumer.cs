using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using SenderConsumer.Common.Domain.Withdrawals;

namespace SenderConsumer.Worker.MessageConsumers
{
    public class ExecuteWithdrawalConsumer : IConsumer<ExecuteWithdrawal>
    {
        private readonly ILogger<ExecuteWithdrawalConsumer> _logger;

        public ExecuteWithdrawalConsumer(ILogger<ExecuteWithdrawalConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ExecuteWithdrawal> context)
        {
            var command = context.Message;

            _logger.LogInformation("Withdrawal has been processed {@context}", command);

            await Task.CompletedTask;
        }
    }
}
