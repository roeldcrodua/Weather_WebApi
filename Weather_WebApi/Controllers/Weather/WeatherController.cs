using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Weather_WebApi.Models;
using Weather_WebApi.Models.Weather;

namespace Weather_WebApi.Controllers.Weather
{
    /* Free (no authentication) weather APIs
 * https://www.metaweather.com/api/
 *      https://www.metaweather.com/api/location/44418
 * http://www.7timer.info/doc.php?lang=en
 *      http://www.7timer.info/bin/civil.php?lon=113.2&lat=23.1&ac=0&unit=metric&output=json&tzshift=0
 * No-cost (but requires authentication) weather APIs
 * https://openweathermap.org/api
 *      https://samples.openweathermap.org/data/2.5/forecast?id=524901&appid=b1b15e88fa797225412429c1c50c122a1
 * https://www.weatherbit.io/api
 *      https://api.weatherbit.io/v2.0/current?city=Raleigh,NC&key=API_KEY
 * https://developer.accuweather.com/apis  
 *      http://dataservice.accuweather.com/forecasts/v1/daily/10day/{locationKey}
 */

    [Route("api/weather")]
    [ApiController]
    public class WeatherController : Controller
    {
        public static string unit = string.Empty;
        public static int days;
        public static WeatherInfo currentWeather;
        public static WeatherData[] currentWeatherData;
        public static WeatherInfo weatherForDays;
        public static WeatherData[] weatherForDaysData;

        private readonly IConfiguration _configuration;

        public WeatherController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<PartialViewResult> GetCurrentWeatherInfo(string zip, string country)
        {

            string API_KEY = _configuration.GetValue<string>("AuthKey");
            Zip.IpController zc = new Zip.IpController();

            if (country == "" || country == null)
            {
                var apiIP = zc.GetIPApiAddress();
                country = apiIP.Result.Country;
            }
            if (zip == "" || zip == null)
            {
                var apiIP = zc.GetIPApiAddress();
                zip = apiIP.Result.Zip;
            }

            WeatherInfo weatherForTheDay = null;
            string URL;
            if (unit == "I" || unit == "S")
                URL = $"https://api.weatherbit.io/v2.0/current?&postal_code={zip}&country={country}&key={API_KEY}&units={unit}";
            else //DEFAULT is Metric
                URL = $"https://api.weatherbit.io/v2.0/current?&postal_code={zip}&country={country}&key={API_KEY}";

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{URL}");
                weatherForTheDay = JsonSerializer.Deserialize<WeatherInfo>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return PartialView("CurrentWeatherInfo_Partial",weatherForTheDay);
        }


    }
}
