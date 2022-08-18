using System.Collections.Generic;
using System.Threading.Tasks;
using NexusHubSharp.Models;
using NexusHubSharp.Options;

namespace NexusHubSharp.Interfaces;

/// <summary>
///     Entry point for the API.
/// </summary>
public interface INexusClient
{
    /// <summary>
    ///     Returns data from the Wowhead news feed.
    /// </summary>
    /// <param name="limit">The max number of returned news posts.</param>
    Task<List<NewsPost>?> GetLatestNewsPosts(int? limit = null);

    /// <summary>
    ///     Get a list of all serverSlugs with their region and slug.
    /// </summary>
    Task<List<ServerInfo>?> GetAllServers();

    /// <summary>
    ///     Get a basic overview of all content phases.
    /// </summary>
    Task<List<ContentPhase>?> GetContentOverview();

    /// <summary>
    ///     Get the currently active content phase.
    /// </summary>
    Task<ContentPhase?> GetActiveContent();

    /// <summary>
    ///     Get crafting price information.
    /// </summary>
    /// <param name="serverSlug">The unique server name. See <see cref="NexusClient.GetAllServers"/> for a list of valid server slugs.</param>
    /// <param name="uniqueName">The unique name for an item. See <see cref="NexusClient.SearchItems"/> to get the unique name for an item.</param>
    Task<CraftingInfo?> GetCraftingInfo(string serverSlug, string uniqueName);

    /// <summary>
    ///     Get the most profitable crafting items.
    /// </summary>
    /// <param name="serverSlug">The unique server name. See <see cref="NexusClient.GetAllServers"/> for a list of valid server slugs.</param>
    /// <param name="options">Options to modify the request sent to NexusHub API.</param>
    Task<List<CraftingDeal>?> GetCraftingDeals(string serverSlug, CraftingDealsOptions? options = null);

    /// <summary>
    ///     Get information about all professions.
    /// </summary>
    Task<List<Profession>?> GetProfessionsDetails();

    /// <summary>
    ///     Get basic stats for all items on a serverSlug.
    /// </summary>
    /// <param name="serverSlug">The unique server name. See <see cref="NexusClient.GetAllServers"/> for a list of valid server slugs.</param>
    Task<ItemsOverview?> GetAllBasicItemStats(string serverSlug);

    /// <summary>
    ///     Get the best possible deals (Difference between minimum buyout and market value).
    /// </summary>
    /// <param name="serverSlug">The unique server name. See <see cref="NexusClient.GetAllServers"/> for a list of valid server slugs.</param>
    /// <param name="options">Options to modify the request sent to NexusHub API.</param>
    Task<List<ItemDeal>?> GetItemDeals(string serverSlug, ItemDealsOptions? options = null);

    /// <summary>
    ///     Get basic item stats.
    /// </summary>
    /// <param name="serverSlug">The unique server name. See <see cref="NexusClient.GetAllServers"/> for a list of valid server slugs.</param>
    /// <param name="uniqueName">The unique name for an item. See <see cref="NexusClient.SearchItems"/> to get the unique name for an item.</param>
    Task<ItemStats?> GetBasicItemStats(string serverSlug, string uniqueName);

    /// <summary>
    ///     Get basic item price statistics.
    /// </summary>
    /// <param name="serverSlug">The unique server name. See <see cref="NexusClient.GetAllServers"/> for a list of valid server slugs.</param>
    /// <param name="uniqueName">The unique name for an item. See <see cref="NexusClient.SearchItems"/> to get the unique name for an item.</param>
    /// <param name="options">Options to modify the request sent to NexusHub API.</param>
    Task<ItemPriceInfo?> GetPriceSnapshots(string serverSlug, string uniqueName,
        PriceSnapshotsOptions? options = null);

    /// <summary>
    ///     Get an item description.
    /// </summary>
    /// <param name="uniqueName">The unique name for an item. See <see cref="NexusClient.SearchItems"/> to get the unique name for an item.</param>
    Task<ItemDescription?> GetItemDescription(string uniqueName);

    /// <summary>
    ///     Get basic information about the last saved scan.
    /// </summary>
    /// <param name="serverSlug">The unique server name. See <see cref="NexusClient.GetAllServers"/> for a list of valid server slugs.</param>
    Task<Scan?> GetLatestScan(string serverSlug);

    /// <summary>
    ///     Find fuzzy matched items based on the given input string.
    /// </summary>
    /// <param name="query">The query you want to search the NexusHub item database for.</param>
    Task<List<SearchResult>?> SearchItems(string query);

    /// <summary>
    ///     Find items starting with the given input string.
    /// </summary>
    /// <param name="prefix">The prefix for the name of an item you want to search for.</param>
    Task<List<SearchResult>?> SearchItemsWithPrefix(string prefix);
}