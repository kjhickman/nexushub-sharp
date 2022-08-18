using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class ServerInfo
{
    [JsonPropertyName("slug")] public string? ServerSlug { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("region")] public string? Region { get; set; }
}