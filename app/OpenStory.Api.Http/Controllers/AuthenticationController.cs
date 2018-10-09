using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenStory.Api.Domain;
using OpenStory.Data;

namespace OpenStory.Api.Http.Controllers
{
    public class AuthenticationController: Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IDataService<User> _dataService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IDataService<User> dataService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

    }
}
