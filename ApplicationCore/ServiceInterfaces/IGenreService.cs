using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IGenreService
    {
        //get movie by genre
        Task<GenreResponseModel> GetGenreDetails(int id);
        Task<IEnumerable<GenreResponseModel>> GetAllGenres();
        Task<IEnumerable<GenreResponseModel>> GetAllGenresApi();
    }
}
