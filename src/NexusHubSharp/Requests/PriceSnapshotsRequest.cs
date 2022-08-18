using System;
using NexusHubSharp.Extensions;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp.Requests;

internal record PriceSnapshotsRequest(string ServerSlug, string UniqueName) : IRequest
{
    public string ServerSlug { get; } = ServerSlug;
    public string UniqueName { get; set; } = UniqueName;
    public int? TimeRangeInDays { get; set; }
    public bool? TreatServerAsRegion { get; set; }
    public int MaxRequestPerInterval => 20;
    public int IntervalInSeconds => 5;

    public Uri ToUri()
    {
        var url = Constants.NexusHubApiUrlV1 + $"items/{ServerSlug}/{UniqueName}/prices";
        var query = string.Empty;
        query = query.AddQuery("timerange", TimeRangeInDays?.ToString());
        query = query.AddQuery("region", TreatServerAsRegion?.ToString());
        return new Uri(url + query);
    }
}