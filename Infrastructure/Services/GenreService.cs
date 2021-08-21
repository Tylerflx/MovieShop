using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        //protected readonly IGenreRepository _genreRepository;
        private readonly IAsyncRepository<Genre> _genreRepository;
        private readonly IMemoryCache _memoryCache;
        public GenreService(IAsyncRepository<Genre> genreRepository, IMemoryCache memoryCache)
        {
            _genreRepository = genreRepository;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<GenreResponseModel>> GetAllGenres()
        {
            //check if cache has genres or not
            //if yes => take genre from cache
            //else => go to db and get genres and store in cache
            //var genres = await _genreRepository.ListAllAsync();
            var genres = await _memoryCache.GetOrCreateAsync("genresData", async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromDays(30);    //expire after 30 days
                return await _genreRepository.ListAllAsync();
            });

            var genresModel = new List<GenreResponseModel>();
            foreach (var genre in genres)
            {
                genresModel.Add(new GenreResponseModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            return genresModel;
        }

        public async Task<GenreResponseModel> GetGenreDetails(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            var genreDetailsModel = new GenreResponseModel
            {
                Id = genre.Id,
                Name = genre.Name
            };

            //genreDetailsModel = new List<GenreResponseModel>();

            //foreach (var movie in genre)
            //{
            //    genreDetailsModel.Movies.Add(new MovieDetailsResponseModel
            //    {
            //        Id = movie.Id,
            //        Title = movie.Title,
            //        Rating = movie.Rating,
            //        PosterUrl = movie.PosterUrl,
            //        ReleaseDate = movie.ReleaseDate,
            //        RunTime = movie.RunTime,
            //        Tagline = movie.Tagline,
            //        Overview = movie.Overview,
            //        Price = movie.Price,
            //        Budget = movie.Budget,
            //        Revenue = movie.Revenue
            //    });
            //}
            return genreDetailsModel;
        }
    }
}
