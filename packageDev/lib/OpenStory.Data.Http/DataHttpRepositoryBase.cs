using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenStory.Data.Http
{
    public abstract class DataHttpRepositoryBase : DataRepositoryBase
    {
        private readonly ILogger<DataHttpRepositoryBase> _logger;
        private readonly DataHttpRepositoryBase _options;
        private readonly IHystrixCommandFactory _hystrixCommandFactory;

        public DataHttpRepositoryBase(HystrixCommandFactory hystrixCommandFactory, ILogger<DataHttpRepositoryBase> logger,
            DataHttpRepositoryBase options)
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
