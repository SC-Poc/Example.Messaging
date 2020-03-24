using Microsoft.Extensions.DependencyInjection;

namespace Subscriber.Worker.MessageConsumers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageConsumers(this IServiceCollection services)
        {
            services.AddTransient<TimeIsOutConsumer>();
            services.AddTransient<IsAliveTriggeredConsumer>();

            return services;
        }
    }
}
