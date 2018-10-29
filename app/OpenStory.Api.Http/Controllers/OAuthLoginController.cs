using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OpenStory.Api.Http.Domain;
using OpenStory.Api.Http.Linking;
using OpenStory.Data;

namespace OpenStory.Api.Http.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IDataService<User> _userDataService;
        private readonly IDataService<string> _jwtDataService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IDataService<User> userDataService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userDataService = userDataService ?? throw new ArgumentNullException(nameof(userDataService));
        }

        [HttpGet, Route("oauth/login/callback", Name = OAuthLinkRelations.OAuthResource.LoginCallback)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Task<HttpResponseMessage>), StatusCodes.Status200OK)]
        public async Task<IActionResult> OAuthLoginCallback()
        {
            _logger.LogInformation("OAuth Login Callbacack");

            var headersJson = JsonConvert.SerializeObject(this.Request.Headers);
            _logger.LogInformation($"OAuth Mobile Log In Request Recieved With Headers {headersJson}");

            Dictionary<string, string> headersDict = this.Request.Headers.HeadersToDictionary();

            //Get details from from headers
            string oAuthProvider = headersDict.FirstOrDefault(x => x.Key == "X-MS-CLIENT-PRINCIPAL-IDP").Value;
            string oAuthProvidedUserId = headersDict.FirstOrDefault(x => x.Key == "X-MS-CLIENT-PRINCIPAL-ID").Value;
            string oAuthProvidedUserHandle = headersDict.FirstOrDefault(x => x.Key == "X-MS-CLIENT-PRINCIPAL-NAME").Value;

            User user;
            if (oAuthProvider == "facebook")
            {
                user = await _userDataService.Get(new Dictionary<string, string>() { { "FacebookId", oAuthProvidedUserId } });
                if (user == null)
                {
                    user = new User()
                    {
                        FacebookId = oAuthProvidedUserId,
                        Handle = oAuthProvidedUserHandle,
                        FacebookHandle = oAuthProvidedUserHandle
                    };
                }

                _logger.LogInformation($"User Created :{JsonConvert.SerializeObject(user)}");
            }
            else if (oAuthProvider == "twitter")
            {
                user = await _userDataService.Get(new Dictionary<string, string>() { { "FacebookId", oAuthProvidedUserId } });
                if (user == null)
                {
                    user = new User()
                    {
                        TwitterId = oAuthProvidedUserId,
                        Handle = oAuthProvidedUserHandle,
                        TwitterHandle = oAuthProvidedUserHandle
                    };
                }
            }
            else
            {
                throw new Exception("Not Authenticated");
            }

            string jwToken = await _jwtDataService.Create(entity: null, cancellationToken: default,
                 new Dictionary<string, object>() { { "User", User } });

            Request.HttpContext.Response.Headers.Add("Authorization", "Bearer " + jwToken);

            //TODO let client pass redirect url and add capability for checks.
            string mobileRedirectUri = "openstory://login?token=" + jwToken;
            return Redirect(mobileRedirectUri);
          
        }

    }
}
