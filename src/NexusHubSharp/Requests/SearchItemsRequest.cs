using System;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp.Requests;

internal record SearchItemsRequest(string Query) : IRequest
{
    public string Query { get; } = Query;
    public int MaxRequestPerInterval => 60;
    public int IntervalInSeconds => 10;

    public Uri ToUri()
    {
        return new Uri(Constants.NexusHubApiUrlV1 + $"search?query={Query}");
    }
}