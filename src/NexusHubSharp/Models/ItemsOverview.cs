using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class ItemsOverview
{
    [JsonPropertyName("slug")] public string? ServerSlug { get; set; }
    [JsonPropertyName("data")] public List<BasicItemStats>? Data { get; set; }
}