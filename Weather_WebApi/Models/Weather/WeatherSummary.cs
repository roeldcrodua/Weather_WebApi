using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weather_WebApi.Models.Weather
{
    public class WeatherSummary
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
