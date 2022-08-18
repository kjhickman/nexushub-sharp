using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NexusHubSharp.Interfaces;

internal interface IThrottler
{
    Task<HttpResponseMessage> Execute(Uri url);
}