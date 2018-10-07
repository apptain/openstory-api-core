using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using OpenStory.Data.Http;

namespace OpenStory.Api.Data.Http.Mongo
{
    public class MongoDataService : HttpDataRepositoryServiceBase
    {
        private readonly MongoProvider _mongoProvider;

        public MongoDataService(HystrixCommandFactory hystrixCommandFactory, 
            ILogger<HttpDataRepositoryServiceBase> logger, HttpDataRepositoryConfig options) : 
            base(hystrixCommandFactory, logger, options)
        {
            _mongoProvider = new MongoProvider(options);
        }

        protected override async Task<ICollection<T>> OnGet<T>(IDictionary<string, object> filters = null, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            try
            {
                _logger.LogTrace("Mongo Get");
                //requires context to be passed
                if (!context.ContainsKey("CollectionName"))
                {
                    throw new ArgumentException("CollectionName must be passed in context");
                }
                var collectionName = context["CollectionName"].ToString();

                var collection = _mongoProvider.Collection(collectionName);
                var entities = await collection.Find(new BsonDocument()).ToListAsync();

                _logger.LogTrace("Mongo Got");
                return (ICollection<T>)Convert.ChangeType(entities, typeof(T));                
            }
            catch (Exception exception)
            {
                //TODO improve error handling 
                _logger.LogError("Error for Mongo OnGet", exception);
                throw exception;
            }
        }

        protected override async Task<T> OnCreate<T>(T entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            try
            {
                _logger.LogTrace("Mongo Save");
                //requires context to be passed
                if (!context.ContainsKey("CollectionName"))
                {
                    throw new ArgumentException("CollectionName must be passed in context");
                }
                var collectionName = context["CollectionName"].ToString();

                var document = entity.ToBsonDocument();
                //TODO make use of InsertOneOptons to pass cancellationToken
                await _mongoProvider.Collection(collectionName).InsertOneAsync(document);

                _logger.LogTrace("Mongo Save");

                //TODO require identity paramaters to be passed and then find inserted doc?
                return (T)Convert.ChangeType(entity, typeof(T));
            }
            catch (Exception exception)
            {
                //TODO improve error handling 
                _logger.LogError("Error for Mongo OnGet", exception);
                throw exception;
            }
        }




    }

}