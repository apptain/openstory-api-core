using Microsoft.Extensions.Logging;
using OpenStory.Data;
using OpenStory.Data.Http;

namespace OpenStory.Api.Services
{
    public class StoryService 
    {
        private readonly ILogger<StoryService> _logger;
        private readonly IDataRepo _dataRepository;

        //private readonly 

        //public MongoDataService(HystrixCommandFactory hystrixCommandFactory,
        //    ILogger<DataHttpRepositoryBase> logger, DataHttpRepositoryOptions options) :
        //    base(hystrixCommandFactory, logger, options)
        //{
        //    _mongoProvider = new MongoProvider(options);
        //}

        //protected override async Task<ICollection<T>> OnGet<T>(IDictionary<string, object> filters = null, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        //{
        //    try
        //    {
        //        _logger.LogTrace("Mongo Get");


        //        _logger.LogTrace("Mongo Got");
        //        return (ICollection<T>)Convert.ChangeType(entities, typeof(T));
        //    }
        //    catch (Exception exception)
        //    {
        //        //TODO improve error handling 
        //        _logger.LogError("Error for Mongo OnGet", exception);
        //        throw exception;
        //    }
        //}

        //protected override async Task<T> OnCreate<T>(T entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        //{
        //    try
        //    {
        //        _logger.LogTrace("Mongo Save");


        //        //TODO require identity paramaters to be passed and then find inserted doc?
        //        return (T)Convert.ChangeType(entity, typeof(T));
        //    }
        //    catch (Exception exception)
        //    {
        //        //TODO improve error handling 
        //        _logger.LogError("Error for Mongo OnGet", exception);
        //        throw exception;
        //    }
        //}
    }
}
