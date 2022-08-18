using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class TooltipInfo
{
    [JsonPropertyName("label")] public string? Label { get; set; }
    [JsonPropertyName("format")] public string? Format { get; set; }
}