namespace NexusHubSharp.Options;

public class ItemDealsOptions
{
    public int? Limit { get; set; }
    public int? Skip { get; set; }
    public int? MinimumItemQuantity { get; set; }
    public bool? Relative { get; set; }
    public string? CompareWithServerSlug { get; set; }
}