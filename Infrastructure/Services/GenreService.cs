using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        protected readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<GenreResponseModel> GetGenreDetails(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            var genreDetailsModel = new GenreResponseModel
            {
                Id = genre.Id,
                Name = genre.Name
            };

            genreDetailsModel.Movies = new List<MovieDetailsResponseModel>();

            foreach (var movie in genre.Movies)
            {
                genreDetailsModel.Movies.Add(new MovieDetailsResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Rating = movie.Rating,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate,
                    RunTime = movie.RunTime,
                    Tagline = movie.Tagline,
                    Overview = movie.Overview,
                    Price = movie.Price,
                    Budget = movie.Budget,
                    Revenue = movie.Revenue
                });
            }
            return genreDetailsModel;
        }
    }
}
