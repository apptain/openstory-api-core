using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;


namespace OpenStory.Data.Http
{
    public abstract class DataHttpProxyingServiceBase : DataRepositoryBase, IDataHttpProxyingService
    {
        protected readonly ILogger<DataHttpProxyingServiceBase> _logger;
        protected readonly DataHttpProxyingServiceOptions _options;
        protected readonly IHystrixCommandFactory _hystrixCommandFactory;

        public DataHttpProxyingServiceBase(HystrixCommandFactory hystrixCommandFactory, ILogger<DataHttpProxyingServiceBase> logger,
             DataHttpProxyingServiceOptions options)
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