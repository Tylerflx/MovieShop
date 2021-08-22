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
    public class CastService : ICastService
    {
        protected readonly ICastRepository _castRepository;
        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<IEnumerable<CastResponseModel>> GetAllCasts()
        {
            var casts = await _castRepository.ListAllAsync();
            var castDetailsModel = new List<CastResponseModel>();
            foreach (var cast in casts)
            {
                castDetailsModel.Add(new CastResponseModel
                {
                    Id = cast.Id,
                    Name = cast.Name,
                    Gender = cast.Gender,
                    ProfilePath = cast.ProfilePath
                });
            }
            return castDetailsModel;
        }

        public async Task<CastResponseModel> GetCastDetails(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            var castDetailsModel = new CastResponseModel
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                ProfilePath = cast.ProfilePath
            };

            castDetailsModel.Movies = new List<MovieDetailsResponseModel>();
            foreach(var movie in cast.MovieCasts)   //need to get Movies through MovieCasts
            {
                castDetailsModel.Movies.Add(new MovieDetailsResponseModel
                {
                    Id = movie.Movie.Id,
                    Title = movie.Movie.Title,
                    Rating = movie.Movie.Rating,
                    PosterUrl = movie.Movie.PosterUrl,
                    ReleaseDate = movie.Movie.ReleaseDate,
                    RunTime = movie.Movie.RunTime,
                    Tagline = movie.Movie.Tagline,
                    Overview = movie.Movie.Overview,
                    Price = movie.Movie.Price,
                    Budget = movie.Movie.Budget,
                    Revenue = movie.Movie.Revenue
                });
            }
            return castDetailsModel;
        }
    }
}
