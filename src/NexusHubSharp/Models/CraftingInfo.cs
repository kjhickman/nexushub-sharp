using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class CraftingInfo
{
    [JsonPropertyName("itemId")] public int ItemId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("uniqueName")] public string? UniqueName { get; set; }
    [JsonPropertyName("slug")] public string? ServerSlug { get; set; }
    [JsonPropertyName("createdBy")] public List<CraftingReagent>? Recipe { get; set; }
    [JsonPropertyName("reagentFor")] public List<CraftableItem>? ReagentFor { get; set; }
}