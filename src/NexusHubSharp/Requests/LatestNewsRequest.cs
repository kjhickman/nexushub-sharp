using System;
using NexusHubSharp.Extensions;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp.Requests;

internal record LatestNewsRequest : IRequest
{
    public int? Limit { get; set; }
    public int MaxRequestPerInterval => 20;
    public int IntervalInSeconds => 5;

    public Uri ToUri()
    {
        const string url = Constants.NexusHubApiUrlV1 + "news";
        var query = string.Empty;
        query = query.AddQuery("limit", Limit?.ToString());
        return new Uri(url + query);
    }
}