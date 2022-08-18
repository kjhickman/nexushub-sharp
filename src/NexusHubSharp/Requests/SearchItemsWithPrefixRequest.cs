using System;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp.Requests;

internal record SearchItemsWithPrefixRequest(string Prefix) : IRequest
{
    public string Prefix { get; } = Prefix;
    public int MaxRequestPerInterval => 60;
    public int IntervalInSeconds => 10;

    public Uri ToUri()
    {
        return new Uri(Constants.NexusHubApiUrlV1 + $"search/suggestions?query={Prefix}");
    }
}