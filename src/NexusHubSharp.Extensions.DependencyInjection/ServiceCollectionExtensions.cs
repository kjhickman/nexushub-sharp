using System;
using Microsoft.Extensions.DependencyInjection;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddNexusClient(this IServiceCollection services,
        Action<NexusClientOptions>? options = null)
    {
        if (options is not null)
        {
            var nexusClientOptions = new NexusClientOptions();
            options.Invoke(nexusClientOptions);
            services.AddSingleton(nexusClientOptions);
        }

        services.AddSingleton<INexusClient, NexusClient>();
    }
}