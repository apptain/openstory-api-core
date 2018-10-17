using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;
using OpenStory.Data;
using OpenStory.Identity;

namespace OpenStory.Auth.Token.Jwt
{
    public class JwtCreateProviderService: Container<string>
    {
        private readonly IDataService<Claim> _claimsDataService;
        private new readonly JwtProviderServiceConfig _config;

        public JwtCreateProviderService(Dictionary<string, IDataService<object>> dataServices, JwtProviderServiceConfig config,
            HystrixCommandFactory hystrixCommandFactory, ILogger<JwtCreateProviderService> logger) :
            base(dataServices, config, hystrixCommandFactory, logger)
        {
            _config = config;
            //_claimsDataService =
            //    dataServices.GetValue<IDataService<Claim>>("ClaimsDataService");

        }

        protected override async Task<string> OnCreate(String entity, CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> parameters = null)
        {
            await Task.Delay(0);
            if (!parameters.ContainsKey("AuthenticatedIdentity"))
            {
                throw new ArgumentNullException("AuthenticatedIdentity",
                    "AuthenticatedIdentity required in parameters");
            }
            AuthenticatedIdentity identity =
                (AuthenticatedIdentity)parameters["AuthenticatedIdentity"];

            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));

            //TODO Implement Claims Provider
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, identity.Id),
                new Claim(JwtRegisteredClaimNames.Jti, await _config.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat,
                    DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString(), ClaimValueTypes.Integer64)
            };

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: _config.Issuer,
                audience: "Authenticated User",
                claims: claims,
                notBefore: _config.NotBefore,
                expires: _config.Expiration,
                signingCredentials: _config.SigningCredentials);

            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            //String returnValue = encodedJwt;
            return encodedJwt;
        }
    }
}
