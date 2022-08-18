using System.Threading.Tasks;

namespace NexusHubSharp.Interfaces;

internal interface IRequester
{
    Task<TResponse?> Get<TResponse, TRequest>(TRequest request) where TRequest : IRequest;
}