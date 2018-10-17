using Newtonsoft.Json;
using System;

namespace OpenStory.Api.Domain.Model
{
    public class Profile
    {
        [JsonProperty(PropertyName = "id")]
        public Guid IdentityId { get; }
        [JsonProperty(PropertyName = "dateCreated")]
        public DateTime DateCreated { get; }

        [JsonProperty(PropertyName = "fistName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "handle")]
        public string Handle { get; set; }

        [JsonProperty(PropertyName = "facebookId")]
        public string FacebookId { get; set; }
        [JsonProperty(PropertyName = "facebookHandle")]
        public string FacebookHandle { get; set; }

        [JsonProperty(PropertyName = "twitterId")]
        public string TwitterId { get; set; }
        [JsonProperty(PropertyName = "twitterHandle")]
        public string TwitterHandle { get; set; }
    }
}
