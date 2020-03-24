using System;
using GreenPipes;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Subscriber.Common.Configuration;
using Subscriber.Common.HostedServices;
using Subscriber.Worker.MessageConsumers;
using Swisschain.Sdk.Server.Common;

namespace Subscriber.Worker
{
    public sealed class Startup : SwisschainStartup<AppConfig>
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void ConfigureServicesExt(IServiceCollection services)
        {
            base.ConfigureServicesExt(services);

            services.AddMessageConsumers();

            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(Config.RabbitMq.HostUrl, host =>
                    {
                        host.Username(Config.RabbitMq.Username);
                        host.Password(Config.RabbitMq.Password);
                    });

                    cfg.UseMessageRetry(y =>
                        y.Exponential(5,
                            TimeSpan.FromMilliseconds(100),
                            TimeSpan.FromMilliseconds(10_000),
                            TimeSpan.FromMilliseconds(100)));

                    cfg.SetLoggerFactory(provider.GetRequiredService<ILoggerFactory>());
                    
                    cfg.ReceiveEndpoint("examples-subscriber-isalive-triggered", e =>
                    {
                        e.Consumer(provider.GetRequiredService<IsAliveTriggeredConsumer>);
                    });

                    cfg.ReceiveEndpoint("examples-subscriber-time-is-out", e =>
                    {
                        e.Consumer(provider.GetRequiredService<TimeIsOutConsumer>);
                    });
                }));

                services.AddHostedService<BusHost>();
            });
        }
    }
}
