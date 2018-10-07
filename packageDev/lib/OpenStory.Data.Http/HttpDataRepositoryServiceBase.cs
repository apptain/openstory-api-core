using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenStory.Data.Http
{
    public abstract class HttpDataRepositoryServiceBase : DataRepositoryBase, IHttpDataRepositoryConfig
    {
        private HttpDataRepositoryConfig _options { get; }
        private IHystrixCommandFactory _hystrixCommandFactory { get; }

        public HttpDataRepositoryServiceBase(HystrixCommandFactory hystrixCommandFactory, ILogger<IDataRepo> logger,
            HttpDataRepositoryConfig options)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = options ?? throw new ArgumentNullException(nameof(options));

            if (hystrixCommandFactory == null)
            {
                throw new ArgumentNullException(nameof(hystrixCommandFactory));
            }
            _hystrixCommandFactory = hystrixCommandFactory;
        }

    }
}
