namespace MVCMovies.Models
{
    public class MoviesActorViewModel : Movie
    {
        public List<int> Selected { get; set; } = new List<int>();
    }
}
