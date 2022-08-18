using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NexusHubSharp.Interfaces;

#pragma warning disable CS4014

namespace NexusHubSharp;

internal class Throttler : IThrottler
{
    private readonly HttpClient _http;
    private readonly int _interval;
    private readonly SemaphoreSlim _semaphore;

    public Throttler(HttpClient http, int requests, int interval)
    {
        _http = http;
        _interval = interval;
        _semaphore = new SemaphoreSlim(requests);
    }

    public async Task<HttpResponseMessage> Execute(Uri url)
    {
        await _semaphore.WaitAsync();
        return await GetAsync(url);
    }

    private static async Task ReleaseAsync(SemaphoreSlim semaphore, int delay)
    {
        await Task.Delay(delay * 1000);
        semaphore.Release();
    }

    private async Task<HttpResponseMessage> GetAsync(Uri url)
    {
        var response = await _http.GetAsync(url);
        ReleaseAsync(_semaphore, _interval);
        return response;
    }
}