# NexusHubSharp

A C# wrapper for the [NexusHub API](https://nexushub.co/developers) for Classic WoW (Warframe support not currently planned).

## Features:
- Built in rate limiting.
- Support for all Classic Wow GET methods for the NexusHUB API.
- Service registration extension method.

## Usage

```csharp
var nexus = new NexusClient();
```
Note: Ensure only one client is used at once to avoid rate limiting. The service is registered as a singleton if you use the dependency injection extension method.
To use that extension in `Program.cs`:

```csharp
builder.Services.AddNexusClient();
```

To get crafting deals for the Benediction server:

```csharp
var deals = await nexus.GetItemDeals("benediction-alliance");
```

Or to use the different options available:

```csharp
var options = new ItemDealsOptions
{
    Limit = limit
};
var deals = await nexus.GetItemDeals("benediction-alliance", options);
```
