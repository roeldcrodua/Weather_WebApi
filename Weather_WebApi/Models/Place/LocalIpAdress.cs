using System.Text.Json.Serialization;

namespace Weather_WebApi.Controllers.Zip
{
    public class LocalIpAdress
    {
        [JsonPropertyName("country_code")]
        public string Country { get; set; }

        [JsonPropertyName("postal")]
        public string Zip { get; set; }

        public string City { get; set; }

        [JsonPropertyName("region")]
        public string State { get; set; }
    }
}