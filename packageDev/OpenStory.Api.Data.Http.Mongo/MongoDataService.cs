using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OpenStory.Data;

namespace Pnnl.Api.Maximo.Data.Http
{
    public class MongoDataService : DataServiceBase
    {
        private readonly ILogger<MongoDataService> _logger;

        public MongoDataService(ILogger<MongoDataService> logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _logger = logger;


        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {

                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        protected override async Task<object> OnGetById(string id, CancellationToken cancellationToken, IDictionary<string, object> context)
        {

            try
            {

            }
            catch (Exception exception)
            {
                _logger.LogError("<{CorrelationId}> Unable to retrieve existing asset. Reason: {@Exception}", context.GetCorrelationId(), exception);
                throw exception;
            }
        }

        protected override async Task<JObject> OnUpdate(string id, JToken jsonBody, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            try
            {
                var document = story.ToBsonDocument();
                await MongoProvider.Collection("stories").InsertOneAsync(document);

                //TODO really assuming success here, need checks and should return db updated doc
                var storyJson = JsonConvert.SerializeObject(story);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(storyJson, Encoding.UTF8, "application/json")
                };
            }
            catch (Exception exception)
            {
                _logger.LogError("<{CorrelationId}> Unable to retrieve existing asset. Reason: {@Exception}", context.GetCorrelationId(), exception);
                throw exception;
            }
        }

        protected override async Task<JObject> OnCreate(JToken jsonBody, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null, JToken procedure = null)
        {
            try
            {
                var document = story.ToBsonDocument();
                await MongoProvider.Collection("stories").InsertOneAsync(document);

                //TODO really assuming success here, need checks and should return db updated doc
                var storyJson = JsonConvert.SerializeObject(story);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(storyJson, Encoding.UTF8, "application/json")
                };


            }
            catch (Exception exception)
            {
                _logger.LogError("<{CorrelationId}> Unable to retrieve existing asset. Reason: {@Exception}", context.GetCorrelationId(), exception);
                throw exception;
            }
        }




    }

}