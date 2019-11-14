using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RecipeLyricsMashup.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet(string sort)
        {
            string recipeEndpoint = "http://www.recipepuppy.com/api/?q=" + sort;
            string recipeJson = GetData(recipeEndpoint);
            ViewData["recipePuppyJson"] = recipeJson;
            return Page();
        }
        public string GetData(string endpoint)
        {
            string downloadedData = "";

            using (WebClient webClient = new WebClient())
            {
                //string resultJson = webClient.DownloadString(endpoint);
                downloadedData = webClient.DownloadString(endpoint);
                
                //string accessToken = "7K8utXpOpn-DCw9kzjn7n7vB6Y7ss0a0RqfmT-03_yA2BabKbstji0cBOoT_dVvI";
                //string geniusEndpoint = "https://api.genius.com/search?q=Fireball&access_token=" + accessToken;
                //string geniusJson = webClient.DownloadString(geniusEndpoint);
                //QuickType.SearchResult searchResults = QuickType.SearchResult.FromJson(geniusJson);
                ////Plant[] allPlants = Plant.FromJson(plantJson);
                //QuickType.Hit[] results = searchResults.Response.Hits;
                //foreach(QuickType.Hit result in results)
                //{
                //    Console.WriteLine(result.Result.Title);
                //    string lyricsEndpoint = "https://api.genius.com/songs/"+ result.Result.Id + "?text_format=plain&access_token=" + accessToken;
                //    string lyricsJson = webClient.DownloadString(lyricsEndpoint);
                //    Console.WriteLine(result.Result.PrimaryArtist.Name);
                //}
            }
            return downloadedData;
        }
    }
}
