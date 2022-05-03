namespace MVCMovies.Models
{
    public class ActorsViewModel
    {
        public List<Actor> Actors { get; set; }
        public ActorFilters Filters { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
