using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NexusHubSharp.Interfaces;

namespace NexusHubSharp;

internal class Requester : IRequester
{
    private readonly HttpClient _http;

    public Requester(HttpClient http)
    {
        _http = http;
    }

    public async Task<TResponse?> Get<TResponse, TRequest>(TRequest request) where TRequest : IRequest
    {
        var url = request.ToUri();
        var response = await _http.GetAsync(url);
        return await JsonSerializer.DeserializeAsync<TResponse>(await response.Content.ReadAsStreamAsync());
    }
}