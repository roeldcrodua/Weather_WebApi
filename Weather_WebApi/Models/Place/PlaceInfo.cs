using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weather_WebApi.Models.Place
{
    public class PlaceInfo
    {
        [JsonPropertyName("place name")]
        public string PlaceName { get; set; }
        public string State { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        [JsonPropertyName("state abbreviation")]
        public string StateAbbreviation { get; set; }
    }
}
