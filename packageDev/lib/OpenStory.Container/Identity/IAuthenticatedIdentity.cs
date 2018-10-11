using System.Security.Principal;

namespace OpenStory.Identity
{
    public interface IAuthenticatedIdentity : IIdentity
    {
        string Id { get; }
        
        //with ExternalId and AuthenticationType (from IIDdentity) we
        //store whatever auth data, 3rd party or propietery, we are
        //using to generate our auth token server side
        string ExternalId { get; set; }
    }
}
