using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class ItemDeal
{
    [JsonPropertyName("itemId")] public int? ItemId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("uniqueName")] public string? UniqueName { get; set; }
    [JsonPropertyName("icon")] public string? IconUrl { get; set; }
    [JsonPropertyName("marketValue")] public int? MarketValue { get; set; }
    [JsonPropertyName("minBuyout")] public int? MinBuyout { get; set; }
    [JsonPropertyName("dealDiff")] public int? DealDifference { get; set; }
    [JsonPropertyName("dealPercentage")] public decimal? DealPercentage { get; set; }
}