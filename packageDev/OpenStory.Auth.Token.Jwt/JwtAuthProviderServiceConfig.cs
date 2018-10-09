using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OpenStory.Auth.Token;
using OpenStory.Data.Provide;

namespace OpenStory.Auth.Token.Jwt
{
    public class JwtAuthProviderServiceConfig : ProviderServiceConfigBase
    {
        public JwtAuthProviderServiceConfig()
        {
            Name = "JWT";
        }

        public string PrivateKey { get; set; }
    }
}
