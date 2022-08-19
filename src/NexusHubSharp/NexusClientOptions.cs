using System.Net.Http;

namespace NexusHubSharp;

public class NexusClientOptions
{
    public bool BypassClientRequestThrottling { get; set; }
    public HttpClient? HttpClient { get; set; }
}