using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using OpenStory.Data;
using OpenStory.Api.Http.Linking;
using OpenStory.Api.Services.Story;

namespace OpenStory.Api.Http.Controllers
{
    [Route("story")]
    public class StoryController: Controller
    {
        private readonly ILogger<StoryController> _logger;
        private readonly IDataRepo _dataService;

        public StoryController(ILogger<StoryController> logger, IDataRepo dataService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        [HttpPost, Route("", Name = StoryLinkRelations.StoryResource.Create)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(JObject), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(Story story)
        {
            try
            {
                var resource = await _dataService.Create(story, HttpContext.RequestAborted);

                return Ok(resource);
            }
            catch (Exception exception)
            {
                _logger.LogError("<{CorrelationId}> Unable to create resource. Reason: {@Exception}", HttpContext.TraceIdentifier, exception);
                throw;
            }
        }

        [HttpGet, Route("", Name = StoryLinkRelations.StoryResource.Get)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resource = await _dataService.Get<Story>(null, HttpContext.RequestAborted);

                return Ok(resource);
            }
            catch (Exception exception)
            {
                _logger.LogError("<{CorrelationId}> Unable to retrieve resource. Reason: {@Exception}", HttpContext.TraceIdentifier, exception);
                throw;
            }
        }

    }
}
