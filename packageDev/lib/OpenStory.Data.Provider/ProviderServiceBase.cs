using System;
using System.Collections.Generic;
using System.Text;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;

namespace OpenStory.Data.Provide
{
    public abstract class ProviderServiceBase : DataServiceBase
    {
        public ProviderServiceBase(IDataServiceConfig config, HystrixCommandFactory hystrixCommandFactory, 
            ILogger<IDataService> logger) : base(config, hystrixCommandFactory, logger)
        {
        }
    }
}
