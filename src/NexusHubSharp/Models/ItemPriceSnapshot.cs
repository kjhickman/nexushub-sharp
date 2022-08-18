using System;
using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class ItemPriceSnapshot
{
    [JsonPropertyName("marketValue")] public int? MarketValue { get; set; }
    [JsonPropertyName("minBuyout")] public int? MinimumBuyout { get; set; }
    [JsonPropertyName("quantity")] public int? Quantity { get; set; }
    [JsonPropertyName("scannedAt")] public DateTime? ScannedAt { get; set; }
}