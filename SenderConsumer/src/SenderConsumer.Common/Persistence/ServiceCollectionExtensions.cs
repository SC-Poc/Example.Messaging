﻿using Microsoft.Extensions.DependencyInjection;

namespace SenderConsumer.Common.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            // TODO: Register repositories

            return services;
        }
    }
}
