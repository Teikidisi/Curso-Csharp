using Microsoft.EntityFrameworkCore;
using MVCMovies.Data;
using MVCMovies.Entities;
using MVCMovies.Models;
using MVCMovies.Services.Abstractions;

namespace MVCMovies.Services
{
    public class MovieArticleService : IMovieArticleService
    {
        private readonly AppDbContext _context;
        public MovieArticleService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<MovieArticles> AddAsync(MovieArticles movie)
        {
            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.MovieArticles.FindAsync(id);

            if (entity == null)
                return false;

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<MovieArticles> EditAsync(MovieArticles movie)
        {
            var entity = await _context.MovieArticles.FindAsync(movie.Id);

            if (entity == null)
                return default;

            entity.Edit(movie.Title, movie.Body);

            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<List<MovieArticles>> GetAllAsync()
        {
            return _context.MovieArticles.ToListAsync();
        }

        public Task<MovieArticles> GetAsync(int id)
        {
            return _context.MovieArticles.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<MovieArticleRecent>> GetRecent()
        {
            var recent = await _context.MovieArticles.OrderBy(c => c.PublishedAt).Take(5)
                .Select(c => new MovieArticleRecent
                {
                    Id = c.Id,
                    Title = c.Title,
                    Body = c.Body.Length > 50 ? c.Body.Substring(50) : c.Body,
                    PublishedAt = c.PublishedAt.ToShortDateString(),
                }).ToListAsync();
            return recent;
        }
    }
}
