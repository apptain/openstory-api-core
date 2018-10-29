using OpenStory.Data;
using OpenStory.Data.Http;

namespace OpenStory.Api.Data.Http.Mongo
{
    public class MongoHttpRepoServiceConfig : IHttpRepoServiceConfig, IMongoHttpRepoServiceConfig
    {
        public MongoHttpRepoServiceConfig()
        {
            Name = "MongoDb";
        }

        public string Name { get; protected set; }

        public virtual string ConnectionString { get; set; }

        public virtual string DatabaseName { get; set; }

    }

}
