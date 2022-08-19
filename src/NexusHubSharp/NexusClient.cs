using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NexusHubSharp.Interfaces;
using NexusHubSharp.Models;
using NexusHubSharp.Options;
using NexusHubSharp.Requests;

namespace NexusHubSharp;

/// <summary>
///     Implementation of <see cref="INexusClient" />
/// </summary>
/// <seealso cref="NexusHubSharp.Interfaces.INexusClient" />
public class NexusClient : INexusClient
{
    private readonly IRequester _requester;

    public NexusClient()
    {
        var httpClient = new HttpClient();
        _requester = new ThrottledRequester(httpClient);
    }

    public NexusClient(NexusClientOptions options)
    {
        var httpClient = options.HttpClient ?? new HttpClient();
        _requester = options.BypassClientRequestThrottling
            ? new Requester(httpClient)
            : new ThrottledRequester(httpClient);
    }

    public NexusClient(HttpClient httpClient)
    {
        _requester = new ThrottledRequester(httpClient);
    }

    public NexusClient(HttpClient httpClient, NexusClientOptions options)
    {
        _requester = options.BypassClientRequestThrottling
            ? new Requester(httpClient)
            : new ThrottledRequester(httpClient);
    }

    /// <inheritdoc />
    public async Task<List<NewsPost>?> GetLatestNewsPosts(int? limit = null)
    {
        try
        {
            var request = new LatestNewsRequest
            {
                Limit = limit
            };
            return await _requester.Get<List<NewsPost>, LatestNewsRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(GetLatestNewsPosts)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<List<ServerInfo>?> GetAllServers()
    {
        try
        {
            var request = new AllServersRequest();
            return await _requester.Get<List<ServerInfo>, AllServersRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(GetAllServers)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<List<ContentPhase>?> GetContentOverview()
    {
        try
        {
            var request = new ContentOverviewRequest();
            return await _requester.Get<List<ContentPhase>, ContentOverviewRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(GetContentOverview)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<ContentPhase?> GetActiveContent()
    {
        try
        {
            var request = new ActiveContentRequest();
            return await _requester.Get<ContentPhase, ActiveContentRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(GetActiveContent)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<CraftingInfo?> GetCraftingInfo(string serverSlug, string uniqueName)
    {
        if (serverSlug is null) throw new ArgumentNullException(nameof(serverSlug));
        if (uniqueName is null) throw new ArgumentNullException(nameof(uniqueName));

        try
        {
            var request = new CraftingInfoRequest(serverSlug, uniqueName);
            return await _requester.Get<CraftingInfo, CraftingInfoRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(GetCraftingInfo)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<List<CraftingDeal>?> GetCraftingDeals(string serverSlug, CraftingDealsOptions? options = null)
    {
        if (serverSlug is null) throw new ArgumentNullException(nameof(serverSlug));

        try
        {
            var request = new CraftingDealsRequest(serverSlug)
            {
                Limit = options?.Limit,
                Skip = options?.Skip,
                MinimumItemQuantity = options?.MinimumItemQuantity
            };
            return await _requester.Get<List<CraftingDeal>, CraftingDealsRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(GetCraftingDeals)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<List<Profession>?> GetProfessionsDetails()
    {
        try
        {
            var request = new ProfessionsDetailsRequest();
            return await _requester.Get<List<Profession>, ProfessionsDetailsRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(GetProfessionsDetails)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<ItemsOverview?> GetAllBasicItemStats(string serverSlug)
    {
        if (serverSlug is null) throw new ArgumentNullException(nameof(serverSlug));

        try
        {
            var request = new AllBasicItemStatsRequest(serverSlug);
            return await _requester.Get<ItemsOverview, AllBasicItemStatsRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(GetAllBasicItemStats)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<List<ItemDeal>?> GetItemDeals(string serverSlug, ItemDealsOptions? options = null)
    {
        if (serverSlug is null) throw new ArgumentNullException(nameof(serverSlug));

        try
        {
            var request = new ItemDealsRequest(serverSlug)
            {
                Limit = options?.Limit,
                Skip = options?.Skip,
                MinimumItemQuantity = options?.MinimumItemQuantity,
                Relative = options?.Relative,
                CompareWithServerSlug = options?.CompareWithServerSlug
            };
            return await _requester.Get<List<ItemDeal>, ItemDealsRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(GetItemDeals)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<ItemStats?> GetBasicItemStats(string serverSlug, string uniqueName)
    {
        if (serverSlug is null) throw new ArgumentNullException(nameof(serverSlug));

        try
        {
            var request = new BasicItemStatsRequest(serverSlug, uniqueName);
            return await _requester.Get<ItemStats, BasicItemStatsRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(GetBasicItemStats)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<ItemPriceInfo?> GetPriceSnapshots(string serverSlug, string uniqueName,
        PriceSnapshotsOptions? options = null)
    {
        if (serverSlug is null) throw new ArgumentNullException(nameof(serverSlug));
        if (uniqueName is null) throw new ArgumentNullException(nameof(uniqueName));

        try
        {
            var request = new PriceSnapshotsRequest(serverSlug, uniqueName)
            {
                TimeRangeInDays = options?.TimeRangeInDays,
                TreatServerAsRegion = options?.TreatServerAsRegion
            };
            return await _requester.Get<ItemPriceInfo, PriceSnapshotsRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(GetPriceSnapshots)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<ItemDescription?> GetItemDescription(string uniqueName)
    {
        if (uniqueName is null) throw new ArgumentNullException(nameof(uniqueName));

        try
        {
            var request = new ItemDescriptionRequest(uniqueName);
            return await _requester.Get<ItemDescription, ItemDescriptionRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(GetItemDescription)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<Scan?> GetLatestScan(string serverSlug)
    {
        if (serverSlug is null) throw new ArgumentNullException(nameof(serverSlug));

        try
        {
            var request = new LatestScanRequest(serverSlug);
            return await _requester.Get<Scan, LatestScanRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(GetLatestScan)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<List<SearchResult>?> SearchItems(string query)
    {
        if (query is null) throw new ArgumentNullException(nameof(query));

        try
        {
            var request = new SearchItemsRequest(query);
            return await _requester.Get<List<SearchResult>, SearchItemsRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(SearchItems)}", e);
        }
    }

    /// <inheritdoc />
    public async Task<List<SearchResult>?> SearchItemsWithPrefix(string prefix)
    {
        if (prefix is null) throw new ArgumentNullException(nameof(prefix));

        try
        {
            var request = new SearchItemsWithPrefixRequest(prefix);
            return await _requester.Get<List<SearchResult>, SearchItemsWithPrefixRequest>(request);
        }
        catch (Exception e)
        {
            throw new NexusHubSharpException($"Error in {nameof(SearchItemsWithPrefix)}", e);
        }
    }
}