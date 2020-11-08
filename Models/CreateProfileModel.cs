using Newtonsoft.Json;

namespace HeroApp.Models
{
    public class CreateProfileModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("notes")]
        public string Note { get; set; }

        [JsonProperty("nationalityIso")]
        public string Country { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }
    }
}
