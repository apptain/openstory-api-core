using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;


namespace OpenStory.Data.Http
{
    public abstract class DataHttpServiceBase : DataRepositoryBase
    {
        protected readonly ILogger<DataHttpServiceBase> _logger;

        public DataHttpServiceBase(ILogger<DataHttpServiceBase> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}