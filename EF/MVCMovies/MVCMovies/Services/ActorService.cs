using Microsoft.EntityFrameworkCore;
using MVCMovies.Data;
using MVCMovies.Models;
using MVCMovies.Services.Abstractions;
using System.Diagnostics;

namespace MVCMovies.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;

        public ActorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Actor> AddAsync(Actor actor)
        {
            await _context.AddAsync(actor); //type Actor EF intuye que es tabla Actors
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var actorDb = await _context.Actors.FindAsync(id);
            if (actorDb == null)
                return false;

            _context.Actors.Remove(actorDb);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Actor> EditAsync(Actor actor)
        {
            var actorDb = await _context.Actors.FindAsync(actor.Id);
            if (actorDb == null)
                return default;

            actorDb.Name = actor.Name;
            actorDb.OscarsWon = actor.OscarsWon;
            actorDb.DateOfBirth = actor.DateOfBirth;

            await _context.SaveChangesAsync();
            return actorDb;
        }

        public Task<List<Actor>> GetActorsAsync(ActorFilters filters)
        {
            //Guardamos el objeto query que se ejecutará en la DB dentro de la variable actors
            //No se obtiene el listado aun hasta el primer query alli si
            var actors = _context.Actors.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Search))
                actors =  actors.Where(p => p.Name.Contains(filters.Search));

            if (filters.From.HasValue && filters.To.HasValue)
            {
                actors = actors.Where(c => c.DateOfBirth >= filters.From && c.DateOfBirth <= filters.To);
            }

            if (filters.Sex.HasValue)
            {
                actors = actors.Where(c => c.Sex == filters.Sex);
            }
            //if (filters.MovieId.HasValue)
            //{
            //    var movie = _context.Movies.FirstOrDefault(m => m.Id.Equals(filters.MovieId));
            //    actors = actors.Where(a => a.Movies.Contains(movie));
            //}

            Debug.WriteLine(actors.ToQueryString());
            //una vez agregado los filtros al query se ejecuta y ya obtienes el listado de actores
            return actors.ToListAsync();
        }

        public Task<Actor> GetAsync(int id)
        {
            return _context.Actors.FindAsync(id).AsTask();
        } 

        public async Task<ICollection<Movie>> GetMoviesWithActor(int id)
        {
            //var moviesWithActors = _context.Movies.Where(c => c.Actors.Count() >= 1);
            var moviesWithActors = from movies in _context.Movies orderby movies select movies;
            List < Movie > Appearances = new List<Movie>();
            foreach (var movie in moviesWithActors)
            {
                foreach (var actor in movie.Actors)
                {
                    if (actor.Id == id)
                    {
                        Appearances.Add(movie);

                    }
                }
            }
            return Appearances;
        }
        public Task<Actor> GetWithRatesAsync(int id)
        {
            return _context.Actors
                .Include(c => c.Movies)
                .Include(c => c.Rates)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> RateActorAsync(UserRateActor rate)
        {
            _context.ActorRates.Add(rate);
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }
    }
}
