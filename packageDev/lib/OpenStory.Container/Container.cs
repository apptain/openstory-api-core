using System;
using System.Collections.Generic;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;
using OpenStory.Data;

namespace OpenStory
{
    public class Container<T> : DataServiceBase<T>, IContainer<T>
    {
        public Dictionary<string, IDataService<object>> _dataServices { get; private set; }

        public Container(Dictionary<string, IDataService<object>> dataServices, IDataServiceConfig config, 
            HystrixCommandFactory hystrixCommandFactory, ILogger<IDataService<T>> logger) : 
            base(config, hystrixCommandFactory, logger)
        {
            _dataServices = dataServices ?? throw new ArgumentNullException(nameof(dataServices));
        }
    }
}
