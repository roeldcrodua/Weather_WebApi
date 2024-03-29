﻿using Microsoft.AspNetCore.Http;
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
    [Route("api/zip")]
    [ApiController]
    public class ZipController : Controller
    {
        [HttpGet]
        public async Task<PartialViewResult> GetZipInfo(string country, string zip)
        {
            var zipDetail = await GetZipDetail(country, zip);
            return PartialView("GetZipInfo_Partial", zipDetail);
        }

        public async Task<ZipInfo> GetZipDetail(string country, string zip)
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

            ZipInfo zipInfo = null;

            using (var client = new HttpClient())
            {
                var json1 = await client.GetStringAsync("http://api.zippopotam.us/" + country + "/" + zip); ;
                zipInfo = JsonSerializer.Deserialize<ZipInfo>(json1, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return zipInfo;
        }
    }
}
