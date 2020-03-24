using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Swisschain.Examples.Publisher.MessagingContract;

namespace Subscriber.Worker.MessageConsumers
{
    public class IsAliveTriggeredConsumer : IConsumer<IsAliveTriggered>
    {
        private readonly ILogger<IsAliveTriggeredConsumer> _logger;

        public IsAliveTriggeredConsumer(ILogger<IsAliveTriggeredConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<IsAliveTriggered> context)
        {
            var evt = context.Message;

            _logger.LogInformation("Is alive triggered {@context}", evt);

            await Task.CompletedTask;
        }
    }
}
