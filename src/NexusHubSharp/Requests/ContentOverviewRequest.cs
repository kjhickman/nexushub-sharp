using System;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp.Requests;

internal record ContentOverviewRequest : IRequest
{
    public int MaxRequestPerInterval => 20;
    public int IntervalInSeconds => 5;

    public Uri ToUri()
    {
        return new Uri(Constants.NexusHubApiUrlV1 + "content");
    }
}