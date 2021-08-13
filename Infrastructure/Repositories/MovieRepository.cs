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
    //EFRepository already inherit 8 methods by reusing 
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext): base(dbContext)
        {
        }
        public async Task<IEnumerable<Movie>> GetHighestRevenueMovies()
        {
            //need to get 30 movies order by revenue
            //need to link DbSet
            //I/O bound method : EF has method that have method both async and non-async
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }
    }
}
