using System;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp.Requests;

internal record ItemDescriptionRequest(string UniqueName) : IRequest
{
    public string UniqueName { get; } = UniqueName;
    public int MaxRequestPerInterval => 20;
    public int IntervalInSeconds => 5;

    public Uri ToUri()
    {
        return new Uri(Constants.NexusHubApiUrlV1 + $"item/{UniqueName}");
    }
}