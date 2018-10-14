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
using OpenStory.Data;
using OpenStory.Data.Http;

namespace OpenStory.Api.Data.Http.Mongo
{
    public class MongoDataService<T> : HttpRepoServiceBase<T>
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase db;

        /// <summary>
        /// BsonDocument IMongoCollection from configured mongodb
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns>Bson Document Collection</returns>
        protected IMongoCollection<BsonDocument> Collection(string collectionName)
        {
            return db.GetCollection<BsonDocument>(collectionName);
        }

        /// <summary>
        /// Generic Typed IMongoCollection from configured mongodb
        /// </summary>
        /// <typeparam name="TMongoType"></typeparam>
        /// <param name="collectionName"></param>
        /// <returns>Generic type T</returns>
        protected IMongoCollection<TMongoType> Collection<TMongoType>(string collectionName)
        {
            return db.GetCollection<TMongoType>(collectionName);
        }

        public MongoDataService(HttpRepoServiceConfig config, HystrixCommandFactory hystrixCommandFactory, 
            ILogger<IDataService<T>> logger) : base(config, hystrixCommandFactory, logger)
        {
            client = new MongoClient(config.ConnectionString);
            db = client.GetDatabase(config.DatabaseName);
        }

        protected override async Task<ICollection<T>> OnGet(IDictionary<string, object> filters = null, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null)
        {
            try
            {
                _logger.LogTrace("Mongo Get");
                //requires parameters to be passed
                if (!parameters.ContainsKey("CollectionName"))
                {
                    throw new ArgumentException("CollectionName must be passed in parameters");
                }
                var collectionName = parameters["CollectionName"].ToString();

                var collection = Collection(collectionName);
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

        protected override async Task<T> OnCreate(T entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null)
        {
            try
            {
                _logger.LogTrace("Mongo Save");
                //requires parameters to be passed
                if (!parameters.ContainsKey("CollectionName"))
                {
                    throw new ArgumentException("CollectionName must be passed in parameters");
                }
                var collectionName = parameters["CollectionName"].ToString();

                var document = entity.ToBsonDocument();
                //TODO make use of InsertOneOptons to pass cancellationToken
                await Collection(collectionName).InsertOneAsync(document);

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