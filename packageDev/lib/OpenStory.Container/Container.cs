using System;
using System.Collections.Generic;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;
using OpenStory.Data;

namespace OpenStory
{
    public class Container : DataServiceBase, IContainer
    {
        public IDictionary<IDataServiceConfig, IDataService> _dataServices { get; private set; }

        public Container(IDictionary<IDataServiceConfig, IDataService> dataService, IDataServiceConfig config, 
            HystrixCommandFactory hystrixCommandFactory, ILogger<IDataService> logger) : 
            base(config, hystrixCommandFactory, logger)
        {
            _dataServices = _dataServices ?? throw new ArgumentNullException(nameof(dataService));
        }
    }
}
