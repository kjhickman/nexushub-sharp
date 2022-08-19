using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp;

internal class ThrottledRequester : IRequester
{
    private readonly HttpClient _http;
    private readonly Dictionary<string, IThrottler> _throttlers;

    public ThrottledRequester(HttpClient http)
    {
        _throttlers = new Dictionary<string, IThrottler>();
        _http = http;
    }

    public async Task<TResponse?> Get<TResponse, TRequest>(TRequest request) where TRequest : IRequest
    {
        HttpResponseMessage response;
        var url = request.ToUri();
        if (_throttlers.TryGetValue(nameof(request), out var throttler))
        {
            response = await throttler.Execute(url);
        }
        else
        {
            _throttlers.Add(nameof(request),
                new Throttler(_http, request.MaxRequestPerInterval, request.IntervalInSeconds));
            response = await _throttlers[nameof(request)].Execute(url);
        }

        return await JsonSerializer.DeserializeAsync<TResponse>(await response.Content.ReadAsStreamAsync());
    }
}