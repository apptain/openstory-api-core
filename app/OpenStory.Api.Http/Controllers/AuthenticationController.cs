using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenStory.Data;

namespace OpenStory.Api.Http.Controllers
{
    public class AuthenticationController: Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IDataRepository _dataService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IDataRepository dataService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }
 
    }
}
