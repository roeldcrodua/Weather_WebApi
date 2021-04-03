using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Weather_WebApi.Models.Place
{
    public class ZipInfo
    {
        [JsonPropertyName("post code")]
        public string ZipCode { get; set; }
        public string Country { get; set; }

        [JsonPropertyName("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        public PlaceInfo[] Places { get; set; }

        public double Latitude
        {
            get { return double.Parse(Places[0].Latitude); }
        }
        public double Longitude
        {
            get { return double.Parse(Places[0].Longitude); }
        }

        public string PlaceName { get { return Places[0].PlaceName; } }
        public string State { get { return Places[0].State; } }
        public string StateAbbreviation { get { return Places[0].StateAbbreviation; } }

        public NearbyPlaces[] Nearby { get; set; }
    }
}
