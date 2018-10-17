using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenStory.Data
{
    public interface IDataServiceTest
    {
        Task<object> Get<TIdentiifer>(TIdentiifer identifier, 
            CancellationToken cancellationToken = default(CancellationToken), 
            IDictionary<string, object> parameters = null);

    }
}
