using MVCMovies.Models;

namespace MVCMovies.Services.Abstractions
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMoviesAsync(MovieFilters filters);
        Task<Movie> GetAsync(int id);
        Task<Movie> AddAsync(Movie movie);
        Task<Movie> EditAsync(Movie movie);
        Task<bool> DeleteAsync(int id);
        Task<bool> RateMovieAsync(UserRate rate);
        Task<Movie> GetWithRatesAsync(int id);
        Task<List<MovieRecent>> GetRecentAsync();
        Task<List<Movie>> GetTopRated();

    }
}
