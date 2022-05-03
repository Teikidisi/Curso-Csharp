namespace MVCMovies.Models
{
    public class MoviesViewModel
    {
        public List<Movie> Movies { get; set; }
        public MovieFilters Filters { get; set; }
        public List<Actor> Actors { get; set; } = new List<Actor>();
    }
}
