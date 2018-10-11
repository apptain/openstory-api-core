using System;
using System.Security.Principal;

namespace OpenStory.Identity
{
    public class AuhenticatedIdentity : IAuthenticatedIdentity
    {
        public string Id { get; set; }

        public string AuthenticationType { get; set; }

        public string ExternalId { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Name { get; set; }

        public AuhenticatedIdentity(string id, string authenticationType, string externalId)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            AuthenticationType = authenticationType;
            ExternalId = externalId;
        }
    }
}
