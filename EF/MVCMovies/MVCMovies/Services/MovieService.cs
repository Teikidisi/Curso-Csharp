using Microsoft.EntityFrameworkCore;
using MVCMovies.Data;
using MVCMovies.Models;
using MVCMovies.Services.Abstractions;

namespace MVCMovies.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie); //type Actor EF intuye que es tabla Actors
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var movieDB = await _context.Movies.FindAsync(id);
            if (movieDB == null)
                return false;

            _context.Movies.Remove(movieDB);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Movie> EditAsync(Movie movie)
        {
            var movieDB = await _context.Movies.FindAsync(movie.Id);
            if (movieDB == null)
                return default;

            movieDB.Title = movie.Title;
            movieDB.Genre = movie.Genre;
            movieDB.ReleaseDate = movie.ReleaseDate;
            movieDB.Rating = movie.Rating;
            movieDB.Price = movie.Price;

            var actors = _context.Movies.Include(x => x.Actors).Where(x => x.Id == movie.Id).SelectMany(x => x.Actors).ToList();

            foreach (var actor in actors)
            {
                movieDB.Actors.Remove(actor);
            }
            await _context.SaveChangesAsync();
            actors = _context.Actors.Where(c => movie.Actors.Contains(c)).ToList();
            movieDB.Actors = actors;

            await _context.SaveChangesAsync();
            return movieDB;
        }

        public Task<Movie> GetAsync(int id) => _context.Movies.Include(c => c.Actors).FirstOrDefaultAsync(c => c.Id == id);

        public Task<List<Movie>> GetMoviesAsync(MovieFilters filters)
        {
            //Guardamos el objeto query que se ejecutará en la DB dentro de la variable actors
            //No se obtiene el listado aun hasta el primer query alli si
            var movies = _context.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(filters.SearchTitle))
                movies = movies.Where(p => p.Title.Contains(filters.SearchTitle));
            
            if (!string.IsNullOrEmpty(filters.SearchGenre))
                movies = movies.Where(p => p.Genre.Contains(filters.SearchGenre));

            if (filters.From.HasValue && filters.To.HasValue)
            {
                movies = movies.Where(c => c.ReleaseDate >= filters.From && c.ReleaseDate <= filters.To);
            }

            if (filters.Rating.HasValue)
            {
                movies = movies.Where(c => c.Rating == filters.Rating);
            }
            if (filters.ActorID.HasValue)
            {
                var actor = _context.Actors.FirstOrDefault(a => a.Id.Equals(filters.ActorID));
                movies = movies.Where(m => m.Actors.Contains(actor));
            }

            //una vez agregado los filtros al query se ejecuta y ya obtienes el listado de actores
            return movies.ToListAsync();
        }

        public Task<Movie> GetWithRatesAsync(int id)
        {
            return _context.Movies
                .Include(c => c.Actors)
                .Include(c => c.Rates)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> RateMovieAsync(UserRate rate)
        {
            _context.MovieRates.Add(rate);
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<List<MovieRecent>> GetRecentAsync()
        {
            var movies = await _context.Movies.OrderByDescending(c => c.ReleaseDate).Take(5)
                .Select(m => new MovieRecent
                {
                    Title = m.Title,
                    ReleaseDate = m.ReleaseDate.ToShortDateString(),
                }).ToListAsync();
            return movies;
        }

        public async Task<List<Movie>> GetTopRated()
        {
            var movies = await _context.Movies.OrderByDescending(m => m.Rates.Average(r => r.Stars)).Take(5)
            .ToListAsync();
            return movies;
        }

    }
}
