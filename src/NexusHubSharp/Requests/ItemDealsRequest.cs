using System;
using NexusHubSharp.Extensions;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp.Requests;

internal record ItemDealsRequest(string ServerSlug) : IRequest
{
    public string ServerSlug { get; } = ServerSlug;
    public int? Limit { get; set; } = 4;
    public int? Skip { get; set; }
    public int? MinimumItemQuantity { get; set; } = 3;
    public bool? Relative { get; set; }
    public string? CompareWithServerSlug { get; set; }
    public int MaxRequestPerInterval => 20;
    public int IntervalInSeconds => 5;

    public Uri ToUri()
    {
        var url = Constants.NexusHubApiUrlV1 + $"items/{ServerSlug}/deals";
        var query = "";
        query = query.AddQuery("limit", Limit?.ToString());
        query = query.AddQuery("skip", Skip?.ToString());
        query = query.AddQuery("min_quantity", MinimumItemQuantity?.ToString());
        query = query.AddQuery("relative", Relative?.ToString());
        query = query.AddQuery("compare_with", CompareWithServerSlug); // TODO: test this, may need to override
        return new Uri(url + query);
    }
}