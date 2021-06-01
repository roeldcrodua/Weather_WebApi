using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weather_WebApi.Models.Weather
{
    public class WeatherInfo
    {
        [JsonPropertyName("data")]
        public WeatherData[] Data { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCodeVal { get; set; }

        [JsonPropertyName("state_code")]
        public string StateCodeVal { get; set; }

        [JsonPropertyName("city_name")]
        public string CityNameVal { get; set; }
    }
}
