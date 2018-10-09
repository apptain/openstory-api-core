using System;
using System.Collections.Generic;
using System.Text;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;

namespace OpenStory.Data.Provide
{
    public abstract class ProviderServiceBase<T> : DataServiceBase<T>
    {
        public ProviderServiceBase(IDataServiceConfig config, HystrixCommandFactory hystrixCommandFactory, 
            ILogger<IDataService<T>> logger) : base(config, hystrixCommandFactory, logger)
        {
        }
    }
}
