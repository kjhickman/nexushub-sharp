using FluentAssertions;
using NexusHubSharp.Extensions;
using Xunit;

namespace NexusHubSharp.Tests.Extensions;

public class StringExtensionsTests
{
    [Fact]
    public void Should_append_single_query()
    {
        var query = "";

        query = query.AddQuery("foo", "bar");

        query.Should().Be("?foo=bar");
    }

    [Fact]
    public void Should_append_multiple_query_parameters()
    {
        var query = "";

        query = query.AddQuery("foo", "bar");
        query = query.AddQuery("test", "query");

        query.Should().Be("?foo=bar&test=query");
    }

    [Fact]
    public void Should_not_append_if_null_or_empty()
    {
        string? query = null;

        query = query.AddQuery("foo", "bar");

        query.Should().Be("?foo=bar");
    }
}