using Microsoft.AspNetCore.Http;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather_WebApi.Models.Place;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DocumentFormat.OpenXml.InkML;

namespace Weather_WebApi.Repositories
{
    public class PlaceRepository
    {
        public PlaceInfo[] GetPlaces()
        {
            return new PlaceInfo[]
            {
                new PlaceInfo
                {
                    PlaceName = "Lake Worth",
                    State = "Florida",
                    StateAbbreviation = "FL"
                },
                new PlaceInfo
                {
                    PlaceName = "Miamisburg",
                    State = "Ohio",
                    StateAbbreviation = "OH"
                }
            };
        }
    }

}
