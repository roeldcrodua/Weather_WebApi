using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weather_WebApi.Models.Place
{
    public class NearbyPlaces
    {
        public double Distance { get; set; }
        public string PlaceName { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
    }
}
