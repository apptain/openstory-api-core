using Hystrix.Dotnet;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenStory.Data.Http
{
    public interface IHttpProxyService<T> : IDataService<T>
    {
        Task<KeyValuePair<object, object>> SessionTokens(CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null);
    }
}
