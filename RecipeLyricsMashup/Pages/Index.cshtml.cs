using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace RecipeLyricsMashup.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using (WebClient webClient = new WebClient())
            {
                string recipePuppyEndpoint = "http://www.recipepuppy.com/api/?q=jambalaya";
                string recipePuppyJson = webClient.DownloadString(recipePuppyEndpoint);
                QuickTypeRecipe.Recipe recipeResult = QuickTypeRecipe.Recipe.FromJson(recipePuppyJson);
                QuickTypeRecipe.Result[] recipes = recipeResult.Results;
                
                string accessToken = System.IO.File.ReadAllText("APIToken.txt");
                string geniusEndpoint = "https://api.genius.com/search?q=jambalaya&access_token=" + accessToken;
                
                string geniusJson = webClient.DownloadString(geniusEndpoint);
                QuickType.SearchResult searchResults = QuickType.SearchResult.FromJson(geniusJson);
                //Plant[] allPlants = Plant.FromJson(plantJson);
                QuickType.Hit[] results = searchResults.Response.Hits;
                //IDictionary<long, Plant> plants = new Dictionary<long, Plant>();
                IDictionary<QuickTypeRecipe.Result, List<QuickType.Hit>> recipesWSongs = new Dictionary<QuickTypeRecipe.Result, List<QuickType.Hit>>();
                //List<QuickTypeRecipe.Result> recipesWSongs= new List<QuickTypeRecipe.Result>();



                //TODO add count to prevent excessive results
                var count = 0;
                foreach (QuickTypeRecipe.Result recipe in recipes)
                {
                    if(count == 0){
                        List<QuickType.Hit> first2 = new List<QuickType.Hit>();
                        var c = 0;
                        foreach (QuickType.Hit result in results)
                        {
                            
                            if (c < 2)
                            {
                                //Console.WriteLine(result.Result.Title);
                                //string lyricsEndpoint = "https://api.genius.com/songs/" + result.Result.Id + "?text_format=plain&access_token=" + accessToken;
                                //string lyricsJson = webClient.DownloadString(lyricsEndpoint);
                                //Console.WriteLine(result.Result.PrimaryArtist.Name);
                                first2.Add(result);
                                c += 1;
                            }


                        }
                        recipesWSongs.Add(recipe, first2);
                    }
                    count += 1;
                    Console.WriteLine(recipe.Title);
                    Console.WriteLine(recipe.Ingredients);
                    
                    
                    //recipesWSongs.Add(recipe);
                }
                //var res = new JsonResult(recipesWSongs);
                //return res;
                //return Json(JsonConvert.SerializeObject(recipesWSongs), JsonRequestBehavior.AllowGet);
                //return new JsonResult(JsonConvert.SerializeObject(recipesWSongs));
            }
        }
    }
}
