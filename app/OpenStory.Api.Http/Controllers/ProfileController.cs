using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using OpenStory.Data;
using OpenStory.Api.Http.Linking;
using OpenStory.Api.Http.Domain;

namespace OpenStory.Api.Http.Controllers
{
    [Route("profile")]
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IDataService<User> _profileDataService;

        public ProfileController(ILogger<ProfileController> logger, IDataService<User> profileDataService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _profileDataService = profileDataService ?? throw new ArgumentNullException(nameof(profileDataService));
        }

        [HttpGet, Route("", Name = ProfileLinkRelations.ProfileResource.Get)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resource = await _profileDataService.Get<User>(null, HttpContext.RequestAborted);

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
