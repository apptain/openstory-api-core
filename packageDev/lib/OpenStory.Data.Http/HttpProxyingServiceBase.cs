using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;

namespace OpenStory.Data.Http
{
    public abstract class HttpProxyingServiceBase : DataRepositoryBase, IHttpProxyingService
    {
        protected IHystrixCommandFactory _hystrixCommandFactory { get; }
        protected HttpProxyingServiceConfig _options { get; }

        public HttpProxyingServiceBase(HystrixCommandFactory hystrixCommandFactory, ILogger<HttpProxyingServiceBase> logger,
             HttpProxyingServiceConfig options)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = options ?? throw new ArgumentNullException(nameof(options));

            if(hystrixCommandFactory == null)
            {
                throw new ArgumentNullException(nameof(hystrixCommandFactory));
            }
            _hystrixCommandFactory = hystrixCommandFactory;
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