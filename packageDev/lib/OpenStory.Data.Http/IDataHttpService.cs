using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenStory.Data.Http
{
    public interface IDataHttpProxyingService
    {     
        Task<KeyValuePair<object, object>> SessionTokens(CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null);
    }
}
