using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;
using OpenStory.Data;
using OpenStory.Data.Http;
using OpenStory.Identity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenStory.Api.Services
{
    public class StoryService<Story> : Container<Story>
    {
        private readonly IDataService<Story> _storyDataService;

        public StoryService(Dictionary<string, IDataService<object>> dataServices, IDataServiceConfig config, 
            HystrixCommandFactory hystrixCommandFactory, ILogger<IDataService<Story>> logger) :
            base(dataServices, config, hystrixCommandFactory, logger)
        {
            if (!dataServices.ContainsKey("StoryDataService"))
            {
                throw new ArgumentNullException("AuthenticatedIdentity",
                    "AuthenticatedIdentity required in parameters");
            }
            
        }

        protected override async Task<Story> OnCreate(Story entity, 
            CancellationToken cancellationToken = default(CancellationToken), 
            IDictionary<string, object> parameters = null)
        {
            try
            {
                _logger.LogTrace("Story Create Call");
                var story = await _storyDataService.Create(entity, cancellationToken, parameters);
                return story;
            }
            catch (Exception exception)
            {
                //TODO improve error handling 
                _logger.LogError("Error for Mongo OnGet", exception);
                throw exception;
            }
        }


        protected override async Task<ICollection<Story>> OnGet(IDictionary<string, object> filters = null, 
            CancellationToken cancellationToken = default(CancellationToken), 
            IDictionary<string, object> parameters = null)
        {
            try
            {
                _logger.LogTrace("Story Create Call");
                return  await _storyDataService.Get(filters, cancellationToken, parameters);
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
