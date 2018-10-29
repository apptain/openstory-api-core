using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;
using OpenStory;
using OpenStory.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenUser.Api.Services
{
    public class AuthenticationService<User> : Container<User>
    {
        private readonly IDataService<User> _userDataService;

        public AuthenticationService(Dictionary<string, IDataService<object>> dataServices, IDataServiceConfig config, 
            HystrixCommandFactory hystrixCommandFactory, ILogger<IDataService<User>> logger) :
            base(dataServices, config, hystrixCommandFactory, logger)
        {
            if (!dataServices.ContainsKey("UserDataService"))
            {
                throw new ArgumentNullException("AuthenticatedIdentity",
                    "AuthenticatedIdentity required in parameters");
            }
            
        }

        protected override async Task<User> OnCreate(User entity, 
            CancellationToken cancellationToken = default(CancellationToken), 
            IDictionary<string, object> parameters = null)
        {
            try
            {
                _logger.LogTrace("User Create Call");
                var user = await _userDataService.Create(entity, cancellationToken, parameters);
                return user;
            }
            catch (Exception exception)
            {
                //TODO improve error handling 
                _logger.LogError("Error for Mongo OnGet", exception);
                throw exception;
            }
        }

        protected override async Task<ICollection<User>> OnGet(IDictionary<string, object> filters = null, 
            CancellationToken cancellationToken = default(CancellationToken), 
            IDictionary<string, object> parameters = null)
        {
            try
            {
                _logger.LogTrace("User Create Call");
                return  await _userDataService.Get(filters, cancellationToken, parameters);
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
