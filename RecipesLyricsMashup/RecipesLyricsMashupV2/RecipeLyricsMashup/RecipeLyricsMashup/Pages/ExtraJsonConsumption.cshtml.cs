using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeLyricsMashup.Pages
{
    public class ExtraJsonConsumptionModel : PageModel
    {
        public void OnGet()
        {
            String countryString = RetrieveData("https://pkgstore.datahub.io/core/country-list/data_json/data/8c458f2d15d9f2119654b29ede6e45b8/data_json.json");
            QuickTypeCountry.Welcome[] countries = QuickTypeCountry.Welcome.FromJson(countryString);
            ViewData["Countries"] = countries;
        }

        public string RetrieveData(string endPoint)
        {
            string downloadedData = "";
            using (WebClient webClient = new WebClient())
            {
                downloadedData = webClient.DownloadString(endPoint);
            }
            return downloadedData;
        }
    }
}


