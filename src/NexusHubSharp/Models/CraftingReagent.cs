using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class CraftingReagent
{
    [JsonPropertyName("itemId")] public int? ItemId { get; set; }
    [JsonPropertyName("amount")] public int? Amount { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("uniqueName")] public string? UniqueName { get; set; }
    [JsonPropertyName("icon")] public string? IconUrl { get; set; }
    [JsonPropertyName("marketValue")] public int? MarketValue { get; set; }
    [JsonPropertyName("vendorPrice")] public int? VendorPrice { get; set; }
}