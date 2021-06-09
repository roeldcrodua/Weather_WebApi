using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weather_WebApi.Models.Weather
{
    public class WeatherData
    {
        [JsonPropertyName("rh")]
        [Display(Name = "Humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("pod")]
        public string PartOfDay { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("ob_time")]
        [Display(Name = "Updated as of ")]
        public string ObservationTime { get; set; }

        [JsonPropertyName("country_code")]
        public string Country { get; set; }

        [JsonPropertyName("clouds")]
        [Display(Name = "Clouds")]
        public int Clouds { get; set; }

        [JsonPropertyName("state_code")]
        public string StateCode { get; set; }

        [JsonPropertyName("city_name")]
        public string CityName { get; set; }

        private double wind_speed;

        [JsonPropertyName("wind_spd")]
        [Display(Name = "Wind")]
        public double WindSpeed 
        {
            get { return wind_speed; }
            set { wind_speed = Math.Round(value, 0); }
        }
    
        [JsonPropertyName("wind_cdir")]
        public string WindDirection { get; set; }

        [JsonPropertyName("slp")]
        public float SeaLevelPressure { get; set; }

        [JsonPropertyName("vis")]
        [Display(Name = "Visibility")]
        public double Visibility { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("snow")]
        public double Snow { get; set; }

        [JsonPropertyName("uv")]
        [Display(Name = "UV Index")]
        public double UVIndex { get; set; }

        private double precipitation;

        [JsonPropertyName("precip")]
        public double Precipitation
        {
            get { return precipitation; }
            set { precipitation = Math.Round(value, 0); }
        }

        [JsonPropertyName("pop")]
        public double Probability { get; set; }

        [JsonPropertyName("wind_dir")]
        public int WindDirectionFlow { get; set; }

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("aqi")]
        public int AirQuality { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("weather")]
        public WeatherSummary WeatherDetail { get; set; }

        private DateTime validDate;

        [JsonPropertyName("valid_date")]
        public DateTime ValidFullDate
        {
            get { return validDate; }
            set { validDate = DateTime.Parse(value.ToShortDateString()); }
        }

        public DateTime ValidDate
        {
            get { return validDate; }
            set { validDate = DateTime.Parse(ValidFullDate.Day.ToString()); }
        }
                
        public DateTime ValidDay
        {
            get { return validDate; }
            set { validDate = DateTime.Parse(ValidFullDate.DayOfWeek.ToString()); }
        }


        private double temperature;

        [JsonPropertyName("temp")]
        public double Temperature
        {
            get { return temperature; }
            set { temperature = Math.Round(value, 0) ; }
        }

        private double low_temperature;

        [JsonPropertyName("dewpt")]
        public double LowTemperature 
        {
            get { return low_temperature; }
            set { low_temperature = Math.Round(value, 0); }
        }

        private double high_temperature;

        [JsonPropertyName("high_temp")]
        [Display(Name = "High Temperature")]
        public double HighTemperature 
        {
            get { return high_temperature; }
            set { high_temperature = Math.Round(value, 0); }
        }

        private double feelsLike_temperature;

        [JsonPropertyName("app_temp")]
        [Display(Name = "Feels like")]
        public double FeelsLikeTemperature 
        {
            get { return feelsLike_temperature; }
            set { feelsLike_temperature = Math.Round(value, 0); }
        }

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
