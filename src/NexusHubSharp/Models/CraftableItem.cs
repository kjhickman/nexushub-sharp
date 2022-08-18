using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NexusHubSharp.Models;

public class CraftableItem
{
    [JsonPropertyName("itemId")] public int? ItemId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("uniqueName")] public string? UniqueName { get; set; }
    [JsonPropertyName("icon")] public string? Icon { get; set; }
    [JsonPropertyName("vendorPrice")] public int? VendorPrice { get; set; }
    [JsonPropertyName("recipes")] public List<int>? Recipes { get; set; }
    [JsonPropertyName("amount")] public List<int>? Amount { get; set; }
    [JsonPropertyName("requiredSkill")] public int? RequiredSkill { get; set; }
    [JsonPropertyName("category")] public string? Category { get; set; }
    [JsonPropertyName("reagents")] public List<CraftingReagent>? Reagents { get; set; }
}