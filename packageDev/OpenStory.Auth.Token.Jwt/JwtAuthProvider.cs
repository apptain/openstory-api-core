using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OpenStory.Auth.Token;

namespace OpenStory.Auth.Token.Jwt
{
    public class JwtAuthProvider : IAuthTokenProvider
    {
        private readonly AuthTokenProviderOptions _options;

        public JwtAuthProvider(AuthTokenProviderOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            //TODO Add private key null check
        }

        public string CreateToken(IPrincipal principal)
        {
            var symmetricKey = Convert.FromBase64String(_options.PrivateKey);
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

        public IPrincipal ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
