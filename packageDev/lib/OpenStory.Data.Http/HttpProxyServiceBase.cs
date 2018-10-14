using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;

namespace OpenStory.Data.Http
{
    public abstract class HttpProxyServiceBase<T> : DataServiceBase<T>, IHttpProxyService<T>
    {
        public HttpProxyServiceBase(IDataServiceConfig config, HystrixCommandFactory hystrixCommandFactory,
           ILogger<IDataService<T>> logger) : base (config, hystrixCommandFactory, logger)
        {        
        }

        public async Task<KeyValuePair<object, object>> SessionTokens(CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnSessionTokens(cancellationToken, parameters ?? new Dictionary<string, object>());
        }

        protected virtual async Task<KeyValuePair<object, object>> OnSessionTokens(CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }
    }
}