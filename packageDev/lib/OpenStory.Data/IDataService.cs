﻿using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenStory.Data
{
    public interface IDataService<T>
    {
        IDataServiceConfig _config { get; }

        IHystrixCommandFactory _hystrixCommandFactory { get; }

        ILogger<IDataService<T>> _logger { get; }

        //Gets one based on identifier value matching key
        Task<T> Get<TIdentiifer>(TIdentiifer identifier, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null);

        //Gets multiple. Filters should be handled and passed with parameters
        Task<ICollection<T>> Get(IDictionary<string, object> filters = null, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null);

        Task<T> Create(T entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null);

        Task<T> Create(ICollection<T> entitities, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null);

        Task<T> Update(T entitity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null);

        Task<T> Update(ICollection<T> entitities, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null);

        //Deletes based on identifier value matching key
        Task<TDeleteResult> Delete<TDeleteResult, TIdentifier>(TIdentifier identifier, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null);

        Task<TDeleteResult> Delete<TDeleteResult, TIdentifier>(ICollection<TIdentifier> identifiers, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null);
    }
}
