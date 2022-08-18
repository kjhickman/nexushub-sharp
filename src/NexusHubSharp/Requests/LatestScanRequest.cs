using System;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp.Requests;

internal record LatestScanRequest(string ServerSlug) : IRequest
{
    public string ServerSlug { get; } = ServerSlug;
    public int MaxRequestPerInterval => 20;
    public int IntervalInSeconds => 5;

    public Uri ToUri()
    {
        return new Uri(Constants.NexusHubApiUrlV1 + $"scans/latest/{ServerSlug}");
    }
}