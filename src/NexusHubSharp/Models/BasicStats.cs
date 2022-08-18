using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class BasicStats
{
    [JsonPropertyName("marketValue")] public int? MarketValue { get; set; }
    [JsonPropertyName("historicalValue")] public int? HistoricalValue { get; set; }
    [JsonPropertyName("minBuyout")] public int? MinimumBuyout { get; set; }
    [JsonPropertyName("numAuctions")] public int? NumberOfAuctions { get; set; }
    [JsonPropertyName("quantity")] public int? Quantity { get; set; }
}