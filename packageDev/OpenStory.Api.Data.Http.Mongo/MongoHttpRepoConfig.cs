using OpenStory.Data;
using OpenStory.Data.Http;

namespace OpenStory.Api.Data.Http.Mongo
{
    public class MongoHttpRepoServiceConfig : HttpRepoServiceConfig, IDataServiceConfig
    {
        public MongoHttpRepoServiceConfig()
        {
            Name = "MongoDb";
        }
    }

}
