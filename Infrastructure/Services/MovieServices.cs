using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
namespace Infrastructure.Services
{
    public class MovieService: IMovieService
    {
        protected readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository; //after inject need to specify in startup add scope
        }
        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            //call repositories and get the real data from database
            //call the movie repository class
            var movies = await _movieRepository.GetHighestRevenueMovies();
            //need to have foreach loop and pass each movie
            //convert
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel { Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl });
            }

            return movieCards;
        }

    }
}
