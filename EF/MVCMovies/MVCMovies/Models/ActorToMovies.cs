namespace MVCMovies.Models
{
    public class ActorToMovies : Actor
    {
        public List<int> Appearances { get; set; } = new List<int>();
    }
}
