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
using Newtonsoft.Json.Linq;
using OpenStory.Data.Http;

namespace OpenStory.Api.Data.Http.Mongo
{
    public class MongoDataService : DataHttpRepositoryBase
    {
        private readonly MongoProvider mongoProvider;

        public MongoDataService(HystrixCommandFactory hystrixCommandFactory, ILogger<DataHttpRepositoryBase> logger, DataHttpRepositoryBase options) : 
            base(hystrixCommandFactory, logger, options)
        {

        }

        //protected override async Task<ICollection<T>> OnGet<T>(IDictionary<string, object> filters = null, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        //{
        //    try
        //    {
        //        //requires context to be passed
        //        if (!context.ContainsKey("CollectionName"))
        //        {
        //            throw new ArgumentException("CollectionName must be passed in context");
        //        }
        //        var collectionName = context["CollectionName"];

        //        var collection = MongoProvider.Collection(collectionName);
        //        var stories = await collection.Find(new BsonDocument()).ToListAsync();
        //        var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; 
        //        var storiesJson = stories.ToJson(jsonWriterSettings);

        //        return new HttpResponseMessage(HttpStatusCode.OK)
        //        {
        //            Content = new StringContent(storiesJson, Encoding.UTF8, "application/json")
        //        };
        //    }
        //    catch (Exception exception)
        //    {
        //        //TODO add error handling 
        //        _logger.LogError("Error for Mongo OnGet", exception);
        //        throw exception;
        //    }
        //}

        //protected override async Task<JObject> OnUpdate(string id, JToken jsonBody, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        //{
        //    try
        //    {
        //        var document = story.ToBsonDocument();
        //        await MongoProvider.Collection("stories").InsertOneAsync(document);

        //        //TODO really assuming success here, need checks and should return db updated doc
        //        var storyJson = JsonConvert.SerializeObject(story);

        //        return new HttpResponseMessage(HttpStatusCode.OK)
        //        {
        //            Content = new StringContent(storyJson, Encoding.UTF8, "application/json")
        //        };
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.LogError("<{CorrelationId}> Unable to retrieve existing asset. Reason: {@Exception}", context.GetCorrelationId(), exception);
        //        throw exception;
        //    }
        //}

        //protected override async Task<JObject> OnCreate(JToken jsonBody, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null, JToken procedure = null)
        //{
        //    try
        //    {
        //        var document = story.ToBsonDocument();
        //        await MongoProvider.Collection("stories").InsertOneAsync(document);

        //        //TODO really assuming success here, need checks and should return db updated doc
        //        var storyJson = JsonConvert.SerializeObject(story);

        //        return new HttpResponseMessage(HttpStatusCode.OK)
        //        {
        //            Content = new StringContent(storyJson, Encoding.UTF8, "application/json")
        //        };


        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.LogError("<{CorrelationId}> Unable to retrieve existing asset. Reason: {@Exception}", context.GetCorrelationId(), exception);
        //        throw exception;
        //    }
        //}




    }

}