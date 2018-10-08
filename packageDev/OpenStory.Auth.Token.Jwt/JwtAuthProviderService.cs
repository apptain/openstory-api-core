using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hystrix.Dotnet;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OpenStory.Auth.Token;
using OpenStory.Data;
using OpenStory.Data.Http;
using OpenStory.Data.Provide;

namespace OpenStory.Auth.Token.Jwt
{
    public class JwtProviderService : ProviderServiceBase, IProviderService
    {
        private readonly string _privateKey;

        public JwtProviderService(JwtAuthProviderServiceConfig config, HystrixCommandFactory hystrixCommandFactory, 
            ILogger<IDataService> logger) : base((IDataServiceConfig)config, hystrixCommandFactory, logger)
        {
            //TODO Add handling for machine encryption
            _privateKey = config.PrivateKey;
        }

        //protected override async Task<ICollection<T>> OnCreate<T>(IDictionary<string, object> filters = null,
        //    CancellationToken cancellationToken = default(CancellationToken), IDictionary<string, object> context = null)
        //{
        //    var symmetricKey = Convert.FromBase64String(_options.PrivateKey);
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var now = DateTime.UtcNow;

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Audience = principal.Identity.
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //            new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(user))
        //        }),
        //        Expires = DateTime.MaxValue,
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var stoken = tokenHandler.CreateToken(tokenDescriptor);
        //    var token = tokenHandler.WriteToken(stoken);
        //}

        //public string CreateToken(IPrincipal principal)
        //{
        //    //var symmetricKey = Convert.FromBase64String(_options.PrivateKey);
        //    //var tokenHandler = new JwtSecurityTokenHandler();

        //    //var now = DateTime.UtcNow;

        //    //var tokenDescriptor = new SecurityTokenDescriptor
        //    //{
        //    //    Audience = principal.Identity.
        //    //    Subject = new ClaimsIdentity(new[]
        //    //    {
        //    //        new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(user))
        //    //    }),
        //    //    Expires = DateTime.MaxValue,
        //    //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
        //    //};

        //    //var stoken = tokenHandler.CreateToken(tokenDescriptor);
        //    //var token = tokenHandler.WriteToken(stoken);

        //    return string.Empty;
        //}

        //public IPrincipal ValidateToken(string token)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
