using System;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp.Requests;

internal record CraftingInfoRequest(string ServerSlug, string UniqueName) : IRequest
{
    public string ServerSlug { get; } = ServerSlug;
    public string UniqueName { get; } = UniqueName;
    public int MaxRequestPerInterval => 20;
    public int IntervalInSeconds => 5;

    public Uri ToUri()
    {
        return new Uri(Constants.NexusHubApiUrlV1 + $"crafting/{ServerSlug}/{UniqueName}");
    }
}