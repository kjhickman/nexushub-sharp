using Microsoft.Extensions.DependencyInjection;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNexusClient(this IServiceCollection services)
    {
        services.AddSingleton<INexusClient, NexusClient>();
        return services;
    }
}