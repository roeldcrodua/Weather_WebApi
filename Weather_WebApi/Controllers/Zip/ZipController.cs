using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Weather_WebApi.Models.Place;

namespace Weather_WebApi.Controllers.Zip
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZipController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetZipInfo(string country, string zip)
        {

            ZipInfo zipInfo = null;
            NearbyInfo nearInfo = null;
            using (var client = new HttpClient())
            {
                var json1 = await client.GetStringAsync("http://api.zippopotam.us/" + country + "/"  + zip);;
                zipInfo = JsonSerializer.Deserialize<ZipInfo>(json1, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var json2 = await client.GetStringAsync("http://api.zippopotam.us/nearby/US/" + zip);
                nearInfo = JsonSerializer.Deserialize<NearbyInfo>(json2, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                zipInfo.Nearby = nearInfo.Nearby;
            }
            return View(zipInfo);
        }

    }
}
