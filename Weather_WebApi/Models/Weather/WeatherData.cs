using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weather_WebApi.Models.Weather
{
    public class WeatherData
    {
        [JsonPropertyName("rh")]
        public int Humidity { get; set; }

        [JsonPropertyName("pod")]
        public string PartOfDay { get; set; }

        [JsonPropertyName("lon")]
        public static double Longitude { get; set; }

        [JsonPropertyName("ob_time")]
        public string ObservationTime { get; set; }

        [JsonPropertyName("country_code")]
        public static string Country { get; set; }

        [JsonPropertyName("clouds")]
        public int Clouds { get; set; }

        [JsonPropertyName("state_code")]
        public static string StateCode { get; set; }

        [JsonPropertyName("city_name")]
        public static string CityName { get; set; }

        [JsonPropertyName("wind_spd")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("wind_cdir_full")]
        public string WindDirectionFull { get; set; }

        [JsonPropertyName("slp")]
        public float SeaLevelPressure { get; set; }

        [JsonPropertyName("vis")]
        public double Visibility { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("dewpt")]
        public double LowTemp { get; set; }

        [JsonPropertyName("snow")]
        public double Snow { get; set; }

        [JsonPropertyName("uv")]
        public double UVIndex { get; set; }

        [JsonPropertyName("precip")]
        public double Precipitation { get; set; }

        [JsonPropertyName("wind_dir")]
        public int WindDirectionFlow { get; set; }

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("aqi")]
        public int AirQuality { get; set; }

        [JsonPropertyName("lat")]
        public static double Latitude { get; set; }

        [JsonPropertyName("weather")]
        public WeatherSummary WeatherDetail { get; set; }

        public string DescriptionDetail
        { get { return WeatherDetail.Description; } }

        [JsonPropertyName("datetime")]
        public string Hour { get; set; }

        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("low_temp")]
        public double LowTemperature { get; set; }

        [JsonPropertyName("high_temp")]
        public double HighTemperature { get; set; }

        [JsonPropertyName("app_temp")]
        public double FeelsLikeTemperature { get; set; }

        [JsonPropertyName("app_max_temp")]
        public double MaxFeelsLikeTemperature { get; set; }

        [JsonPropertyName("app_min_temp")]
        public double MinFeelsLikeTemperature { get; set; }

        [JsonPropertyName("moon_phase_lunation")]
        public double MoonPhase { get; set; }

        [JsonPropertyName("moonrise_ts")]
        public int MoonRise { get; set; }

        [JsonPropertyName("moonset_ts")]
        public int MoonSet { get; set; }

        [JsonPropertyName("sunrise_ts")]
        public int SunRiseDaily { get; set; }

        [JsonPropertyName("sunset_ts")]
        public int SunSetDaily { get; set; }

        [JsonPropertyName("ts")]
        public int TimeStart { get; set; }
    }
}
