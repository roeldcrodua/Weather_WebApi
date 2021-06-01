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
using Microsoft.Extensions.Configuration;

namespace Weather_WebApi.Controllers.Zip
{
    [Route("api/ip")]
    [ApiController]
    public class IpController : Controller
    {
        [HttpGet]
            public async Task<LocalIpAdress> GetIPApiAddress()
        {
            var API_Key = "20ba7d98306ce226f8bc4d5b44da15826b927c3c2a5b9cd6d92f8278";
            string ipV = null;
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    if (ip.ToString().Length == 39)
                    {
                        ipV = ip.ToString();
                    }
                }
            }

            using (var client = new HttpClient())
            {
                LocalIpAdress IPInfo = null;
                var jsonIp = await client.GetStringAsync($"https://api.ipdata.co/{ipV}?api-key={API_Key}");
                IPInfo = JsonSerializer.Deserialize<LocalIpAdress>(jsonIp, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return IPInfo;
            }
            
        }
    }
}
