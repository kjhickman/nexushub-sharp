using System;
using NexusHubSharp.Extensions;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp.Requests;

internal record CraftingDealsRequest(string ServerSlug) : IRequest
{
    public string ServerSlug { get; } = ServerSlug;
    public int? Limit { get; set; }
    public int? Skip { get; set; }
    public int? MinimumItemQuantity { get; set; }
    public int MaxRequestPerInterval => 20;
    public int IntervalInSeconds => 5;

    public Uri ToUri()
    {
        var url = Constants.NexusHubApiUrlV1 + $"crafting/{ServerSlug}/deals";
        var query = string.Empty;
        query = query.AddQuery("limit", Limit?.ToString());
        query = query.AddQuery("skip", Skip?.ToString());
        query = query.AddQuery("min_quantity", MinimumItemQuantity?.ToString());
        return new Uri(url + query);
    }
}