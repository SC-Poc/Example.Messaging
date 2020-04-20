using Microsoft.Extensions.DependencyInjection;

namespace SenderConsumer.Worker.MessageConsumers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageConsumers(this IServiceCollection services)
        {
            // TODO: Just an example
            services.AddTransient<ExecuteWithdrawalConsumer>();

            return services;
        }
    }
}
