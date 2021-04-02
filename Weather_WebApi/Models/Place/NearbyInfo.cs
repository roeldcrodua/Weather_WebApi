using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weather_WebApi.Models.Place
{
    public class NearbyInfo
    {
        [JsonPropertyName("near longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("near latitude")]
        public double Latitude { get; set; }

        public NearbyPlaces[] Nearby { get; set; }
    }
}
