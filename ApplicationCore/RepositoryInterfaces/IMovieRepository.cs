﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<IEnumerable<Movie>> Get30HighestRevenueMovies();

        Task<IEnumerable<Movie>> Get30HighestRatedMovies();

        Task<Genre> GetGenreById(int id);
        Task<List<Review>> Get30MovieReviews(int id);

    }
}
