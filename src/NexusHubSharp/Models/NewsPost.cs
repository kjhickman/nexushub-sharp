using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class NewsPost
{
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("guid")] public string? Link { get; set; }
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonPropertyName("categories")] public List<string>? Categories { get; set; }
    [JsonPropertyName("isoDate")] public DateTime? PublishDate { get; set; }
}