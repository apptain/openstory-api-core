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

namespace OpenStory.Auth.Token.Jwt
{
    public class JwtProviderService<T> : ProviderServiceBase<T>, IProviderService<T>
    {
        private readonly string _privateKey;

        public JwtProviderService(JwtAuthProviderServiceConfig config, HystrixCommandFactory hystrixCommandFactory, 
            ILogger<IDataService<T>> logger) : base((IDataServiceConfig)config, hystrixCommandFactory, logger)
        {
            //TODO Add handling for machine encryption
            _privateKey = config.PrivateKey;
        }

        private async Task<List<Claim>> GetValidClaims( user)
        {
            IdentityOptions _options = new IdentityOptions();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
                new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName)
            };
            
            return claims;
        }

        protected override async Task<Jwt> OnCreate(IDictionary<string, object> filters = null,
         CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        {
            var symmetricKey = Convert.FromBase64String(_options.PrivateKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = princ
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(user))
                }),
                Expires = DateTime.MaxValue,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);
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
