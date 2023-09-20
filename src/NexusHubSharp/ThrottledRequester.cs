using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp;

internal class ThrottledRequester : IRequester
{
    private readonly HttpClient _http;
    private readonly ConcurrentDictionary<string, IThrottler> _throttlers;

    public ThrottledRequester(HttpClient http)
    {
        _throttlers = new ConcurrentDictionary<string, IThrottler>();
        _http = http;
    }

    public async Task<TResponse?> Get<TResponse, TRequest>(TRequest request) where TRequest : IRequest
    {
        var url = request.ToUri();

        var throttler = _throttlers.GetOrAdd(nameof(request),
                            new Throttler(_http, request.MaxRequestPerInterval, request.IntervalInSeconds))
                        ?? _throttlers[nameof(request)];

        var response = await throttler.Execute(url);

        return await JsonSerializer.DeserializeAsync<TResponse>(await response.Content.ReadAsStreamAsync());
    }
}