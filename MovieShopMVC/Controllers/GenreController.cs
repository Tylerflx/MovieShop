using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public async Task<IActionResult> Index()
        {
            //show list of genres in the header of Layout Page
            //Hint: Use Partial View and use BS to show genres
            //Use <a> of genres when click go to db and show the list of movies belongs to that genres
            var genres = await _genreService.GetAllGenres();
            return View(genres);
        }
        public async Task<IActionResult> Details(int id)
        {
            var genreDetails = await _genreService.GetGenreDetails(id);
            return View(genreDetails);
        }
        
    }
}
