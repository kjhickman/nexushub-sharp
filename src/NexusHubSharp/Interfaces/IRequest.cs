using System;

namespace NexusHubSharp.Interfaces;

internal interface IRequest
{
    public int MaxRequestPerInterval { get; }
    public int IntervalInSeconds { get; }
    Uri ToUri();
}