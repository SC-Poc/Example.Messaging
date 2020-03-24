using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swisschain.Examples.Publisher.MessagingContract;

namespace Publisher.Worker.HostedServices
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int _executionsCount;
        private readonly ILogger<TimedHostedService> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private Timer _timer;

        public TimedHostedService(ILogger<TimedHostedService> logger,
            IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, 
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var count = Interlocked.Increment(ref _executionsCount);

            _publishEndpoint.Publish(new TimeIsOut
            {
                At = DateTime.UtcNow,
                TotalCount = count
            });

            _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
