using System.Security.Principal;

namespace OpenStory.Auth.Token
{
    public interface IAuthTokenProvider
    {
        string CreateToken(IPrincipal principal);

        IPrincipal ValidateToken(string token);
    }
}
