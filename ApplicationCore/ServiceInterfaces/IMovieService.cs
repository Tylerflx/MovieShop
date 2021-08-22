using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        //display top 100 movies
        Task<List<MovieCardResponseModel>> GetTopRevenueMovies();

        //get top rated movies
        Task<List<MovieDetailsResponseModel>> GetTopRatedMovies();

        //get movie details by id
        Task<MovieDetailsResponseModel> GetMovieDetails(int id);

        Task<IEnumerable<MovieCardResponseModel>> GetAllMovies();
        Task<GenreResponseModel> GetGenreDetails(int id);

        Task<IEnumerable<MovieReviewsResponseModel>> GetAllReviews(int id);

        

    }
}
