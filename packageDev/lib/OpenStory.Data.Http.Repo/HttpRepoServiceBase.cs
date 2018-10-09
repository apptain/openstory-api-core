using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;

namespace OpenStory.Data.Http
{
    public abstract class HttpRepoServiceBase<T> : DataServiceBase<T>
    {
        public HttpRepoServiceBase(HttpRepoServiceConfig config, HystrixCommandFactory hystrixCommandFactory, 
            ILogger<IDataService<T>> logger) : base((IDataServiceConfig)config, hystrixCommandFactory, logger)
        {
        }
    }
}
