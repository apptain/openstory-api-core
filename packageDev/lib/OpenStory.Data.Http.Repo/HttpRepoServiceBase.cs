using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;

namespace OpenStory.Data.Http
{
    public abstract class HttpRepoServiceBase : DataServiceBase
    {
        public HttpRepoServiceBase(HttpRepoServiceConfig config, HystrixCommandFactory hystrixCommandFactory, 
            ILogger<IDataService> logger) : base((IDataServiceConfig)config, hystrixCommandFactory, logger)
        {
        }
    }
}
