using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weather_WebApi.Models.Place
{
    public class NearbyPlaces
    {
        private double distance;
        public double Distance
        {
            get { return distance; }
            set { distance = Math.Round(value, 2);; }
        }

        [JsonPropertyName("place name")]
        public string PlaceName { get; set; }

        [JsonPropertyName("post code")]
        public string PostCode { get; set; }
        public string State { get; set; }

        [JsonPropertyName("state abbreviation")]
        public string StateAbbreviation { get; set; }
    }
}
