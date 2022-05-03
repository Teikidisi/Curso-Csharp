using MVCMovies.Models;

namespace MVCMovies.Services.Abstractions
{
    public interface IActorService
    {
        Task<List<Actor>> GetActorsAsync(ActorFilters filters);
        Task<Actor> AddAsync(Actor actor);
        Task<Actor> EditAsync(Actor actor);
        Task<bool> DeleteAsync(int id);
        Task<Actor> GetAsync(int id);
        Task<ICollection<Movie>> GetMoviesWithActor(int id);
        Task<bool> RateActorAsync(UserRateActor rate);
        Task<Actor> GetWithRatesAsync(int id);
    }
}
