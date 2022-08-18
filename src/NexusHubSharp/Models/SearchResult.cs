using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class SearchResult
{
    [JsonPropertyName("itemId")] public int? ItemId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("uniqueName")] public string? UniqueName { get; set; }
    [JsonPropertyName("imgUrl")] public string? ImageUrl { get; set; }
}