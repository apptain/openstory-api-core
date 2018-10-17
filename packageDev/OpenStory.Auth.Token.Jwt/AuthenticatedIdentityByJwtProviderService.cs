using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OpenStory.Data;
using OpenStory.Data.Http;
using OpenStory.Data.Provide;
using OpenStory.Identity;

namespace OpenStory.Auth.Token.Jwt
{
    public class AuthenticatedIdentityByJwtProviderService : Container<AuthenticatedIdentity>
    {
        private readonly IDataService<Claim> _claimsDataService;
        private new readonly JwtProviderServiceConfig _config;

        public AuthenticatedIdentityByJwtProviderService(Dictionary<string, IDataService<object>> dataServices, JwtProviderServiceConfig config,
            HystrixCommandFactory hystrixCommandFactory, 
            ILogger<AuthenticatedIdentityByJwtProviderService> logger) :
            base(dataServices, config, hystrixCommandFactory, logger)
        {
            _config = config;
            //_claimsDataService =
            //    dataServices.GetValue<IDataService<Claim>>("ClaimsDataService");
        }

        protected override async Task<AuthenticatedIdentity> OnGet<String>(String identifier, 
            CancellationToken cancellationToken, IDictionary<string, object> parameters)
        {
            //TODO handle errors in param
            string token = identifier.ToString();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
            {
                //TODO improve
                throw new Exception("Token is not valid");
            }

            var symmetricKey = Convert.FromBase64String(_config.PrivateKey);

            var validationParameters = new TokenValidationParameters()
            {
                RequireExpirationTime = false,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
            };

            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

            AuthenticatedIdentity authenticatedIdentity = new AuthenticatedIdentity("", "", "");

            return authenticatedIdentity;

            //return (T)Convert.ChangeType(principal, typeof(T));

        }
    }
}
