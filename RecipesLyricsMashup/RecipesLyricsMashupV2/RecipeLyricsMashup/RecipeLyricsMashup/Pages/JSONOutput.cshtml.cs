﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickType;

namespace RecipeLyricsMashup.Pages
{
    public class JSONOutputModel : PageModel
    {
        public JsonResult OnGet(string search)
        {
            if (String.IsNullOrEmpty(search))
            {
                search = "jambalaya";
            }
            List<Hit> geniusResults = GetSongs(search);
            return new JsonResult(geniusResults);
        }
        public List<Hit> GetSongs(string search)
        {

            List<Hit> results = CallGeniusAPI(search);
            if (results.Count() < 10)
            {
                List<String> searchTerms = search.Split(" ").ToList();
                foreach (string searchTerm in searchTerms)

                {
                    List<Hit> apiResults = CallGeniusAPI(searchTerm);
                    while (results.Count() <= 10)
                    {
                        foreach (Hit apiResult in apiResults)
                        {
                            results.Add(apiResult);
                        }

                    }

                }
            }
            return results;
        }

        public List<Hit> CallGeniusAPI(string search)
        {
            string accessToken = System.IO.File.ReadAllText("APIToken.txt");
            string geniusEndpoint = "https://api.genius.com/search?q=" + search + "&access_token=" + accessToken;
            string geniusResultsJson = GetData(geniusEndpoint);
            SearchResult searchResults = SearchResult.FromJson(geniusResultsJson);
            List<Hit> results = searchResults.Response.Hits.ToList();
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