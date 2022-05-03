using MVCMovies.Entities;
using MVCMovies.Models;

namespace MVCMovies.Services.Abstractions
{
    public interface IMovieArticleService
    {
        Task<List<MovieArticles>> GetAllAsync();
        Task<MovieArticles> AddAsync(MovieArticles movie);
        Task<MovieArticles> EditAsync(MovieArticles movie);
        Task<bool> DeleteAsync(int id);
        Task<MovieArticles> GetAsync(int id);
        Task<List<MovieArticleRecent>> GetRecent();

    }
}
