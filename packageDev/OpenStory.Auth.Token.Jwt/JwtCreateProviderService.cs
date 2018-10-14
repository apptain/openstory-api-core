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

        //var user = await _userManager.FindByNameAsync(applicationUser.UserName);

        //// Get valid claims and pass them into JWT
        //var claims = await GetValidClaims(user);

        //// Create the JWT security token and encode it.
        //var jwt = new JwtSecurityToken(
        //    issuer: _jwtOptions.Issuer,
        //    audience: _jwtOptions.Audience,
        //    claims: claims,
        //    notBefore: _jwtOptions.NotBefore,
        //    expires: _jwtOptions.Expiration,
        //    signingCredentials: _jwtOptions.SigningCredentials);


        //private ClaimsIdentity GetClaimsIdentity(User user)
        //{
        //    // Here we can save some values to token.
        //    // For example we are storing here user id and email
        //    Claim[] claims = new[]
        //    {
        //        new Claim(ClaimTypes.Name, user.Id.ToString()),
        //        new Claim(ClaimTypes.Email, user.Email)
        //    };
        //    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");

        //    // Adding roles code
        //    // Roles property is string collection but you can modify Select code if it it's not
        //    claimsIdentity.AddClaims(user.Roles.Select(role => new Claim(ClaimTypes.Role, role)));
        //    return claimsIdentity;
        //} 



        public string CreateToken(IPrincipal principal)
        {
            //var symmetricKey = Convert.FromBase64String(_options.PrivateKey);
            //var tokenHandler = new JwtSecurityTokenHandler();

            //var now = DateTime.UtcNow;

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Audience = principal.Identity.
            //    Subject = new ClaimsIdentity(new[]
            //    {
            //        new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(user))
            //    }),
            //    Expires = DateTime.MaxValue,
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            //};

            //var stoken = tokenHandler.CreateToken(tokenDescriptor);
            //var token = tokenHandler.WriteToken(stoken);

            return string.Empty;
        }

        //public IPrincipal ValidateToken(string token)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
