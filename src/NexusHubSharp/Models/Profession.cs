using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class Profession
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("icon")] public string? IconUrl { get; set; }
}