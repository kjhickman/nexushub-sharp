using System;

namespace NexusHubSharp;

public class NexusHubSharpException : Exception
{
    public NexusHubSharpException()
    {
    }

    public NexusHubSharpException(string message) : base(message)
    {
    }

    public NexusHubSharpException(string message, Exception inner) : base(message, inner)
    {
    }
}