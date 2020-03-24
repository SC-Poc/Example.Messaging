using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Swisschain.Examples.Publisher.MessagingContract;

namespace Subscriber.Worker.MessageConsumers
{
    public class TimeIsOutConsumer : IConsumer<TimeIsOut>
    {
        private readonly ILogger<TimeIsOutConsumer> _logger;

        public TimeIsOutConsumer(ILogger<TimeIsOutConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<TimeIsOut> context)
        {
            var evt = context.Message;

            _logger.LogInformation("Time is out {@context}", evt);

            await Task.CompletedTask;
        }
    }
}
