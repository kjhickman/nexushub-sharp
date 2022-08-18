namespace NexusHubSharp.Extensions;

internal static class StringExtensions
{
    public static bool IsNullOrWhiteSpace(this string? str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    public static string? AddQuery(this string? queryString, string key, string? value)
    {
        if (value.IsNullOrWhiteSpace()) return queryString;
        if (queryString.IsNullOrWhiteSpace()) return $"?{key}={value}";

        return queryString + $"&{key}={value}";
    }
}