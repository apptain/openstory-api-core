using Hystrix.Dotnet;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenStory.Data.Http
{
    public interface IHttpProxyService : IDataService
    {
        Task<KeyValuePair<object, object>> SessionTokens(CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null);
    }
}
