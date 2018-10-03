using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenStory.Data
{
    /// <summary>
    /// Provides a base repository capable of retrieving and persisting information.
    /// </summary>
    public abstract class DataRepositoryBase : IDataRepository
    {
        public async Task<T> Get<T, TIdentiifer>(TIdentiifer identifier, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnGet<T, TIdentiifer>(identifier, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<T> OnGet<T, TIdentiifer>(TIdentiifer identifier, CancellationToken cancellationToken, IDictionary<string, object> context)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<ICollection<T>> Get<T>(IDictionary<string, object> filters = null, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnGet<T>(filters, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<ICollection<T>> OnGet<T>(IDictionary<string, object> filters = null, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<T> Create<T>(T entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnCreate<T>(entity, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<T> OnCreate<T>(T entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<T> Create<T>(ICollection<T> entities, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnCreate<T>(entities, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<T> OnCreate<T>(ICollection<T> entitities, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<T> Update<T>(T entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnUpdate<T>(entity, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<T> OnUpdate<T>(T entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<T> Update<T>(ICollection<T> entities, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await OnUpdate<T>(entities, cancellationToken, context ?? new Dictionary<string, object>());
        }

        protected virtual async Task<T> OnUpdate<T>(ICollection<T> entities,  CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
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