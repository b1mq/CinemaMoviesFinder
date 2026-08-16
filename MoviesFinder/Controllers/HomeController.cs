using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MoviesFinder.Models;
using MoviesFinder.Services;

namespace MoviesFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieServices;

        public HomeController(IMovieService movieServices)
        {
            _movieServices = movieServices;
        }

        public async Task<IActionResult> Index(string? movie)
        {
            
            if (movie == null)
            {
                return View();
            }

            
            if (string.IsNullOrWhiteSpace(movie))
            {
                return View(new MoviesModel { Response = "False", Error = "No Film Name!" });
            }
            var res = await _movieServices.GetMoviesAsync(movie);
            return View(res);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
