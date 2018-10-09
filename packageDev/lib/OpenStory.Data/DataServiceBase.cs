using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;

namespace OpenStory.Data
{
    /// <summary>
    /// Provides a base repository capable of retrieving and persisting information.
    /// </summary>
    public abstract class DataServiceBase<T> : IDataService<T>
    {
        /// <summary>
        /// _config should be set in constructor as needed
        /// </summary>
        public IDataServiceConfig _config { get; private set; }

        public IHystrixCommandFactory _hystrixCommandFactory { get; private set; }

        public ILogger<IDataService<T>> _logger { get; private set; }

        public DataServiceBase(IDataServiceConfig config, HystrixCommandFactory hystrixCommandFactory, 
            ILogger<IDataService<T>> logger)
        {            
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _hystrixCommandFactory = hystrixCommandFactory ?? throw new ArgumentNullException(nameof(hystrixCommandFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<T> Get<TIdentiifer>(TIdentiifer identifier, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnGet<T, TIdentiifer>(identifier, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<T> OnGet<T, TIdentiifer>(TIdentiifer identifier, CancellationToken cancellationToken, IDictionary<string, object> context)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<ICollection<T>> Get(IDictionary<string, object> filters = null, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnGet(filters, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<ICollection<T>> OnGet(IDictionary<string, object> filters = null, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<T> Create(T entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnCreate(entity, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<T> OnCreate(T entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<T> Create(ICollection<T> entities, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnCreate(entities, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<T> OnCreate(ICollection<T> entitities, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<T> Update(T entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnUpdate(entity, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<T> OnUpdate(T entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<T> Update(ICollection<T> entities, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnUpdate(entities, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<T> OnUpdate(ICollection<T> entities,  CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<TDeleteResult> Delete<TDeleteResult, TIdentifier>(TIdentifier identifier, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnDelete<TDeleteResult, TIdentifier>(identifier, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<TDeleteResult> OnDelete<TDeleteResult, TIdentifier>(TIdentifier identifier, CancellationToken cancellationToken, IDictionary<string, object> context)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<TDeleteResult> Delete<TDeleteResult, TIdentifier>(ICollection<TIdentifier> identifiers, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnDelete<TDeleteResult, TIdentifier>(identifiers, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<TDeleteResult> OnDelete<TDeleteResult, TIdentifier>(ICollection<TIdentifier> identifiers, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }
    }

}