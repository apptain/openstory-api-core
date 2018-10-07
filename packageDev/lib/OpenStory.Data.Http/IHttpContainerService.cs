using Hystrix.Dotnet;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenStory.Data.Http
{
    public interface IHttpContainerService
    {  
        IDataRepo _repository { get; }
        HttpProxyingServiceConfig _options { get; }
        IDictionary<string, IDataRepo> _repositories { get; }

        protected IHystrixCommandFactory _hystrixCommandFactory { get; }
        

    }
}
