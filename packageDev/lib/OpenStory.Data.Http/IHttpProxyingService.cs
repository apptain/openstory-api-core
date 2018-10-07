using Hystrix.Dotnet;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenStory.Data.Http
{
    public interface IHttpProxyingService : IDataRepo
    {
        IHystrixCommandFactory _hystrixCommandFactory { get; }

        HttpProxyingServiceConfig _options { get; }

        Task<KeyValuePair<object, object>> SessionTokens(CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null);
    }
}
