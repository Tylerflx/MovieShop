using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase  //controlbase doesnt need view
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //api/movies
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();
            if (!movies.Any())
            {
                return NotFound("No Movies Found.");
            }
            return Ok(movies);
        }
        //api/Movies/id
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetMovieDetails(int id)
        {
            var movies = await _movieService.GetMovieDetails(id);
            return Ok(movies);
        }
        //api/movies/toprated
        [Route("toprated")]
        [HttpGet]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.GetTopRatedMovies();
            if (!movies.Any())
            {
                return NotFound("No Movies Found.");
            }
            return Ok(movies);
        }
        // api/movies/toprevenue
        [Route("toprevenue")]
        [HttpGet]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            //along with data you need to return http status code
            var movies = await _movieService.GetTopRevenueMovies();
            if (!movies.Any())
            {
                return NotFound("No Movies Found.");
            }
            return Ok(movies);  //c# data return need to convert to json
        }
        //api/movies/genre/{genreId}
        [Route("genre/{genreId}")]
        [HttpGet]
        public async Task<IActionResult> GetGenreById(int genreId)
        {
            var movies = await _movieService.GetGenreDetails(genreId);
            return Ok(movies);  //c# data return need to convert to json
        }
        //api/movies/genre/{genreId}
        [Route("{id}/reviews")]
        [HttpGet]
        public async Task<IActionResult> GetMovieReviews(int id)
        {
            var reviews = await _movieService.GetAllReviews(id);
            if (!reviews.Any())
            {
                return NotFound("No Movies Found.");
            }
            return Ok(reviews);
        }



    }
}
