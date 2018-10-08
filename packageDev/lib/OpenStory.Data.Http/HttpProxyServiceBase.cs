using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;

namespace OpenStory.Data.Http
{
    public abstract class HttpProxyServiceBase : DataServiceBase, IHttpProxyService
    {
        public HttpProxyServiceBase(IDataServiceConfig config, HystrixCommandFactory hystrixCommandFactory,
           ILogger<IDataService> logger) : base (config, hystrixCommandFactory, logger)
        {        
        }

        public async Task<KeyValuePair<object, object>> SessionTokens(CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnSessionTokens(cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<KeyValuePair<object, object>> OnSessionTokens(CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }
    }
}