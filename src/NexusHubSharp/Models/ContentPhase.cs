using System;
using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class ContentPhase
{
    [JsonPropertyName("contentPhase")] public int? Phase { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("releaseDate")] public DateTime? ReleaseDate { get; set; }
}