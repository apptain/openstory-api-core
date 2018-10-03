using MongoDB.Bson;
using MongoDB.Driver;
using OpenStory.Data.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenStory.Api.Data.Http.Mongo
{
    public class MongoProvider
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase db;

        public MongoProvider(DataHttpRepositoryOptions options)
        {
            client = new MongoClient(options.ConnectionString);
            db = client.GetDatabase(options.DatabaseName);
        } 

        /// <summary>
        /// BsonDocument IMongoCollection from configured mongodb
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns>Bson Document Collection</returns>
        public IMongoCollection<BsonDocument> Collection(string collectionName)
        {
            return db.GetCollection<BsonDocument>(collectionName);
        }

        /// <summary>
        /// Generic Typed IMongoCollection from configured mongodb
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <returns>Generic type T</returns>
        public IMongoCollection<T> Collection<T>(string collectionName)
        {
            return db.GetCollection<T>(collectionName);
        }
    }
}
