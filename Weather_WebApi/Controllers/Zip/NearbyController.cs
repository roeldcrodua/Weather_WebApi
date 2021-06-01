using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Weather_WebApi.Models.Place;
using System.Net;
using System.Net.Sockets;

namespace Weather_WebApi.Controllers.Zip
{
    [Route("api/nearby")]
    [ApiController]
    public class NearbyController : Controller
    {
        [HttpGet]
        public async Task<PartialViewResult> GetNearbyInfo(string country, string zip)
        {
            IpController zc = new IpController();

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

            NearbyInfo nearInfo = null;
            
            using (var client = new HttpClient())
            {
                var json2 = await client.GetStringAsync("http://api.zippopotam.us/nearby/" + country + "/" + zip);
                nearInfo = JsonSerializer.Deserialize<NearbyInfo>(json2, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            }
            return PartialView("GetNearbyInfo_Partial", nearInfo);
        }

    }
}
