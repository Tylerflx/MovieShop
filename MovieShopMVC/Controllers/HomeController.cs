using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private MovieService _movieService;
        public HomeController()
        {
            //put _movieService in constructor so we can use it or access anywhere
            _movieService = new MovieService();
        }

        public IActionResult Index()

        {
            var movies = _movieService.GetTopRevenueMovies();
            //get some movies and display
            //pass data obj to view

            //viewbag
            ViewBag.PageTitle = "Top Revenue Movies";
            //view data
            ViewData["TotalMovies"] = movies.Count();
            //Strongly typed models
            return View(movies);    //passing obj
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
