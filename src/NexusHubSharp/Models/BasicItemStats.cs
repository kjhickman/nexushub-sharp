using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class BasicItemStats : BasicStats
{
    [JsonPropertyName("itemId")] public int? ItemId { get; set; }
    [JsonPropertyName("previous")] public BasicStats? Previous { get; set; }
}