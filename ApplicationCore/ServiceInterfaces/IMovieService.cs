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

        //get movie details by id
        Task<MovieDetailsResponseModel> GetMovieDetails(int id);

    }
}
