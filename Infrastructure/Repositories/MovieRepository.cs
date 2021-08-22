using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Movie>> Get30HighestRatedMovies()
        {
            //can optimize
            var movies = await _dbContext.Movies.Include(m => m.Reviews).ToListAsync();
            if (movies == null)
            {
                throw new Exception($"No Movie Found");
            }
            foreach (var movie in movies)
            {
                var movieRating = movie.Reviews.DefaultIfEmpty().Average(r => r == null ? 0 : r.Rating);
                if (movieRating > 0)
                {
                    movie.Rating = movieRating;
                }
            }
            var topRating =  movies.OrderByDescending(m => m.Rating).Take(30).ToList();
            return topRating;
        }
        public async Task<IEnumerable<Movie>> Get30HighestRevenueMovies()
        {
            return await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
        }

        public async Task<List<Review>> Get30MovieReviews(int id)
        {
            //get review join movie on movieid, join user on userid 
            var movies = await _dbContext.Reviews.Include(m => m.Movie).Where(m => m.MovieId == id).Include(m => m.User).Take(30).ToListAsync();
            if (movies == null)
            {
                throw new Exception($"No Movie Found for the id {id}");
            }
            return movies;
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast).Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                throw new Exception($"No Movie Found for the id {id}");
            }

            var movieRating = await _dbContext.Reviews.Where(m => m.MovieId == id).DefaultIfEmpty().AverageAsync(r => r == null ? 0 : r.Rating);

            movie.Rating = movieRating;
            return movie;

        }

        public async Task<Genre> GetGenreById(int id)
        {
            //var movies = await _dbContext.Genres.Include(m => m.Movies).Where(g => g.Id == id).Take(100).ToListAsync() ;
            var movies = await _dbContext.Genres.Include(m => m.Movies).FirstOrDefaultAsync(m => m.Id == id);
            if (movies == null)
            {
                throw new Exception($"No Movie Found for the genreid {id}");
            }
            return movies;
        }

        //get all movies
        public override async Task<IEnumerable<Movie>> ListAllAsync()
        {
            var movies = await _dbContext.Movies.Take(1000).ToListAsync();
            return movies;
        }
    }
}