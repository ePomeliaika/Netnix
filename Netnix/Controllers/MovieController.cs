using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Netnix.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Netnix.Controllers
{
    public class MovieController : Controller
    // Grabbing soon to be released movies from API
    {
        Uri baseAddress = new Uri("https://virtserver.swaggerhub.com/BartvdPost/NetNix/0.2.0/soon/");
        HttpClient client;
        public MovieController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            List<Movie> movieList = new List<Movie>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
            // Converting from JSON to C# 
                movieList = JsonConvert.DeserializeObject<List<Movie>>(data);
            // Sorting by release date using Lambda expression
                movieList = movieList.OrderBy(a => a.releaseDate).ToList();


            }
            // Selecting Top 5 from the sorted movie list
            var Top5 = movieList.Take(5);
            return View(Top5);
        }

        // Grabing API with ID variable for selected movie ID by clicking "details"
        public ActionResult Details (string id)
        { 
            Uri baseAddress2 = new Uri($"https://virtserver.swaggerhub.com/BartvdPost/NetNix/0.2.0/movie/{id}");
            HttpClient client;

            client = new HttpClient();
            client.BaseAddress = baseAddress2;

            MovieDetails selectedMovie = new MovieDetails();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string movieData = response.Content.ReadAsStringAsync().Result;
                // Converting from JSON to C# 
                selectedMovie = JsonConvert.DeserializeObject<MovieDetails>(movieData);
                    
            }
            return View(selectedMovie);
        }
    }  
}

