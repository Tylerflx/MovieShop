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
        //protected readonly IGenreService _genreService;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository; //after inject need to specify in startup add scope
            
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetAllMovies()   //get 1000 movies
        {
            var movies = await _movieRepository.ListAllAsync();
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel { Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl });
            }

            return movieCards;

        }

        public async Task<IEnumerable<MovieReviewsResponseModel>> GetAllReviews(int id)
        {
            //show review details by movieid
            var movies = await _movieRepository.Get30MovieReviews(id);
            var movieDetailsModel = new List<MovieReviewsResponseModel>();
            foreach (var movie in movies)
            {
                movieDetailsModel.Add(new MovieReviewsResponseModel
                {
                    MovieId = movie.MovieId,
                    UserId = movie.UserId,
                    Title = movie.Movie.Title,
                    FirstName = movie.User.FirstName,
                    LastName = movie.User.LastName,
                    Rating = movie.Rating,
                    PosterUrl = movie.Movie.PosterUrl,
                    ReviewText = movie.ReviewText
                });
            }
            return movieDetailsModel;
        }

        public async Task<GenreResponseModel> GetGenreDetails(int id)
        {
            //Show List of movies with the same genre id
            
            var movies = await _movieRepository.GetGenreById(id);
            var movieDetailsModel = new GenreResponseModel
            {
                Id = movies.Id,
                Name = movies.Name
            };
            movieDetailsModel.Movies = new List<MovieDetailsResponseModel>();
            foreach (var movie in movies.Movies)
            {
                movieDetailsModel.Movies.Add(new MovieDetailsResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
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

            return movieDetailsModel;
            
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            var movieDetailsModel = new MovieDetailsResponseModel
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
            };

            movieDetailsModel.Casts = new List<CastResponseModel>();

            foreach (var cast in movie.MovieCasts)
            {
                movieDetailsModel.Casts.Add(new CastResponseModel
                {
                    Id = cast.CastId,
                    Name = cast.Cast.Name,
                    Character = cast.Character,
                    ProfilePath = cast.Cast.ProfilePath,
                   
                    
                });
            }

            movieDetailsModel.Genres = new List<GenreResponseModel>();

            foreach (var genre in movie.Genres)
            {
                movieDetailsModel.Genres.Add(new GenreResponseModel { Id = genre.Id, Name = genre.Name });
            }

            return movieDetailsModel;
        }

        public async Task<List<MovieDetailsResponseModel>> GetTopRatedMovies()
        {
            //show lists of movies with
            var movies = await _movieRepository.Get30HighestRatedMovies();
            //mapping process
            var movieCards = new List<MovieDetailsResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieDetailsResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
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
            return movieCards;
        }

        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            //call repositories and get the real data from database
            //call the movie repository class
            var movies = await _movieRepository.Get30HighestRevenueMovies();
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
