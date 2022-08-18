using System;
using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class Scan
{
    [JsonPropertyName("scanId")] public int? ScanId { get; set; }
    [JsonPropertyName("scannedAt")] public DateTime? ScannedAt { get; set; }
}