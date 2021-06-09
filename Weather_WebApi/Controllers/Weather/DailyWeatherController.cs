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
 *      https://api.weatherbit.io/v2.0/forecast/daily?city=Raleigh,NC&key=API_KEY
 * https://developer.accuweather.com/apis  
 *      http://dataservice.accuweather.com/forecasts/v1/daily/10day/{locationKey}
 */

    [Route("api/daily")]
    [ApiController]
    public class DailyWeatherController : Controller
    {
        private readonly IConfiguration _configuration;

        public DailyWeatherController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<PartialViewResult> GetDailyWeatherInfo(string zip, string country, string units, double? lat, double? lon)
        {
            string URL;
            string API_KEY = _configuration.GetValue<string>("Weather_API_KEY");
            Zip.IpController zc = new Zip.IpController();

            if ((lat == null) || (lon == null))
            {
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

                if (units == "I")
                    URL = $"https://api.weatherbit.io/v2.0/forecast/daily?&postal_code={zip}&country={country}&key={API_KEY}&units={units}";
                else //DEFAULT is Metric
                    URL = $"https://api.weatherbit.io/v2.0/forecast/daily?&postal_code={zip}&country={country}&key={API_KEY}";
            }
            else
            {
                if (units == "I")
                    URL = $"https://api.weatherbit.io/v2.0/forecast/daily?&lat={lat}&lon={lon}&key={API_KEY}&units={units}";
                else //DEFAULT is Metric
                    URL = $"https://api.weatherbit.io/v2.0/forecast/daily?&lat={lat}&lon={lon}&key={API_KEY}";
            }

            WeatherInfo weatherForDays = null;

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{URL}");
                weatherForDays = JsonSerializer.Deserialize<WeatherInfo>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return PartialView("Weather/DailyWeatherInfo_Partial",weatherForDays);
        }


    }
}
