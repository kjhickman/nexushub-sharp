using System;
using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class StatsInfo
{
    [JsonPropertyName("lastUpdated")] public DateTime? LastUpdated { get; set; }
    [JsonPropertyName("current")] public BasicStats? Current { get; set; }
    [JsonPropertyName("previous")] public BasicStats? Previous { get; set; }
}