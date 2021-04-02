using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Weather_WebApi.Models.Place;
using Weather_WebApi.Models.Zip;
using Weather_WebApi.Repositories;

namespace Weather_WebApi.Controllers.Place
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        public static async Task<ZipInfo> GetInfo(string zip)
        {
            ZipInfo info = null;
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("http://api.zippopotam.us/US/" + zip);
                info = JsonSerializer.Deserialize<ZipInfo>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return info;
        }

        public static async Task<NearbyInfo> GetNearbyPlaces(string zip)
        {
            NearbyInfo info = null;
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("http://api.zippopotam.us/nearby/US/" + zip);
                info = JsonSerializer.Deserialize<NearbyInfo>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return info;
        }
    }
}
