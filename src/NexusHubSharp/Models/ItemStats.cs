using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class ItemStats
{
    [JsonPropertyName("itemId")] public int? ItemId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("uniqueName")] public string? UniqueName { get; set; }
    [JsonPropertyName("icon")] public string? IconUrl { get; set; }
    [JsonPropertyName("tags")] public List<string>? Tags { get; set; }
    [JsonPropertyName("requiredLevel")] public int? RequiredLevel { get; set; }
    [JsonPropertyName("itemLevel")] public int? ItemLevel { get; set; }
    [JsonPropertyName("sellPrice")] public int? SellPrice { get; set; }
    [JsonPropertyName("vendorPrice")] public int? VendorPrice { get; set; }
    [JsonPropertyName("tooltip")] public List<TooltipInfo>? ToolTip { get; set; }
    [JsonPropertyName("itemLink")] public string? ItemLink { get; set; }
    [JsonPropertyName("statsInfo")] public StatsInfo? StatsInfo { get; set; }
}