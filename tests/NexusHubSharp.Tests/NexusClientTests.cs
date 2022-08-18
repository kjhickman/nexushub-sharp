using FluentAssertions;
using NexusHubSharp.Options;
using Xunit;

namespace NexusHubSharp.Tests;

public class NexusClientTests
{
    private readonly NexusClient _sut;

    public NexusClientTests()
    {
        _sut = new NexusClient();
    }

    [Theory]
    [InlineData(null, 4)]
    [InlineData(5, 5)]
    public async Task Should_get_latest_news_posts(int? limit, int count)
    {
        var result = await _sut.GetLatestNewsPosts(limit);

        result.Should().HaveCount(count);
    }

    [Fact]
    public async Task Should_get_all_servers()
    {
        var result = await _sut.GetAllServers();

        result.Should().AllSatisfy(server => server.Should().NotBeNull());
        result.Should().HaveCount(84);
    }

    [Fact]
    public async Task Should_get_content_overview()
    {
        var result = await _sut.GetContentOverview();

        result.Should().AllSatisfy(contentPhase => contentPhase.Should().NotBeNull());
    }

    [Fact]
    public async Task Should_get_active_content()
    {
        var result = await _sut.GetActiveContent();

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_get_crafting_info()
    {
        var result = await _sut.GetCraftingInfo("benediction-alliance", "iron-ore");
        result.Should().NotBeNull();
    }

    [Theory]
    [InlineData(null, 4)]
    [InlineData(5, 5)]
    public async Task Should_get_crafting_deals(int? limit, int count)
    {
        var options = new CraftingDealsOptions
        {
            Limit = limit
        };
        var result = await _sut.GetCraftingDeals("benediction-alliance", options);

        result.Should().HaveCount(count);
    }

    [Fact]
    public async Task Should_get_professions_details()
    {
        var result = await _sut.GetProfessionsDetails();

        result.Should().HaveCount(13);
    }

    [Fact]
    public async Task Should_get_all_basic_item_stats()
    {
        var result = await _sut.GetAllBasicItemStats("benediction-alliance");

        result!.Data.Should().AllSatisfy(stats => stats.Should().NotBeNull());
    }

    [Theory]
    [InlineData(null, 4)]
    [InlineData(5, 5)]
    public async Task Should_get_item_deals(int? limit, int count)
    {
        var options = new ItemDealsOptions
        {
            Limit = limit
        };

        var result = await _sut.GetItemDeals("benediction-alliance", options);

        result.Should().HaveCount(count);
    }

    [Fact]
    public async Task Should_get_basic_item_stats()
    {
        var result = await _sut.GetBasicItemStats("benediction-alliance", "iron-ore");

        result.Should().NotBeNull();
    }

    [Theory]
    [InlineData(null, 7)]
    [InlineData(14, 14)]
    public async Task Should_get_price_snapshots(int? timeRange, int returnedTimeRange)
    {
        var options = new PriceSnapshotsOptions
        {
            TimeRangeInDays = timeRange
        };

        var result = await _sut.GetPriceSnapshots("benediction-alliance", "iron-ore", options);

        result!.TimeRangeInDays.Should().Be(returnedTimeRange);
        result.Snapshots!.OrderBy(x => x.ScannedAt).First().ScannedAt.Should()
            .BeOnOrAfter(DateTime.UtcNow.AddDays(-returnedTimeRange));
    }

    [Fact]
    public async Task Should_get_item_description()
    {
        var result = await _sut.GetItemDescription("iron-ore");

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_get_latest_scan()
    {
        var result = await _sut.GetLatestScan("benediction-alliance");

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_search_items()
    {
        var result = await _sut.SearchItems("iron");

        result.Should().Contain(x => x.UniqueName == "iron-ore");
    }

    [Fact]
    public async Task Should_search_items_with_prefix()
    {
        var result = await _sut.SearchItemsWithPrefix("iron");

        result.Should().Contain(x => x.UniqueName == "iron-ore");
    }
}