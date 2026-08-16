using MoviesFinder.Models;

namespace MoviesFinder.Services
{
    public interface IMovieService
    {
        Task<MoviesModel> GetMoviesAsync(string movie);
    }
}