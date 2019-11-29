using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickType;
using QuickTypeRecipe;
using Result = QuickTypeRecipe.Result;

namespace RecipeLyricsMashup.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet(string search)
        {
            bool searchValid = (!String.IsNullOrEmpty(search));


            Result[] recipes = GetRecipes(search);
            ViewData["recipePuppyJson"] = recipes;
            //Encoding ascii = Encoding.ASCII;
            Console.WriteLine(search);


            Hit[] results = GetSongs(search);
            ViewData["geniusResults"] = results;
            return Page();
        }
        public IActionResult OnPost(string search)
        {
            Console.WriteLine(search);
            return Page();
        }
        public Result[] GetRecipes(string search)
        {
            string recipeEndpoint = "http://www.recipepuppy.com/api/?q=" + search;
            string recipeJson = GetData(recipeEndpoint);
            Recipe recipeResult = Recipe.FromJson(recipeJson);
            Result[] recipes = recipeResult.Results;
            return recipes;
        }
        public Hit[] GetSongs(string search)
        {
            string accessToken = System.IO.File.ReadAllText("APIToken.txt");
            string geniusEndpoint = "https://api.genius.com/search?q=" + search + "&access_token=" + accessToken;
            string geniusResultsJson = GetData(geniusEndpoint);
            SearchResult searchResults = SearchResult.FromJson(geniusResultsJson);
            Hit[] results = searchResults.Response.Hits;
            return results;
        }
        public string GetData(string endpoint)
        {
            string downloadedData = "";

            using (WebClient webClient = new WebClient())
            {
                downloadedData = webClient.DownloadString(endpoint);


            }
            return downloadedData;
        }
    }
}
