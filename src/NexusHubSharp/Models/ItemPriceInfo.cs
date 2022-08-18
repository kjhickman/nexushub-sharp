using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class ItemPriceInfo
{
    [JsonPropertyName("slug")] public string? ServerSlug { get; set; }
    [JsonPropertyName("itemId")] public int? ItemId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("uniqueName")] public string? UniqueName { get; set; }
    [JsonPropertyName("timerange")] public int? TimeRangeInDays { get; set; }
    [JsonPropertyName("data")] public List<ItemPriceSnapshot>? Snapshots { get; set; }
}