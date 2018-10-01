using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenStory.Api.Data
{
    public interface IDataService
    {
        //Gets one based on identifier value matching key
        Task<T> Get<T, TIdentiifer>(TIdentiifer identifier, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null);

        //Gets multiple. Filters should be handled and passed with context
        Task<ICollection<T>> Get<T>(IDictionary<string, object> filters = null, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null);

        Task<T> Create<T>(T entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null);

        Task<T> Create<T>(ICollection<T> entitities, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null);

        Task<T> Update<T>(T entitity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null);

        Task<T> Update<T>(ICollection<T> entitities, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null);

        //Deletes based on identifier value matching key
        Task<TDeleteResult> Delete<TDeleteResult, TIdentifier>(TIdentifier identifier, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null);

        Task<TDeleteResult> Delete<TDeleteResult, TIdentifier>(ICollection<TIdentifier> identifiers, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null);
    }
}
