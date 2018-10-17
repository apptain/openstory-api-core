//using System;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Newtonsoft.Json.Linq;
//using OpenStory.Data;
//using OpenStory.Api.Http.Linking;
//using OpenStory.Api.Domain.Model;

//namespace OpenStory.Api.Http.Controllers
//{
//    [Route("profile")]
//    public class ProfileController: Controller
//    {
//        private readonly ILogger<ProfileController> _logger;
//        private readonly IDataService<Profile> _dataService;

//        public ProfileController(ILogger<ProfileController> logger, IDataService<Profile> dataService)
//        {
//            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
//        }

//        [HttpGet, Route("", Name = ProfileLinkRelations.ProfileResource.Get)]
//        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
//        public async Task<IActionResult> Get()
//        {
//            try
//            {
//                var resource = await _dataService.Get<Profile>(null, HttpContext.RequestAborted);

//                return Ok(resource);
//            }
//            catch (Exception exception)
//            {
//                _logger.LogError("<{CorrelationId}> Unable to retrieve resource. Reason: {@Exception}", HttpContext.TraceIdentifier, exception);
//                throw;
//            }
//        }

//    }
//}
