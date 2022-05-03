namespace MVCMovies.Models
{
    public class ActorFilters
    {
        public string Search { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public Sex? Sex { get; set; }
    }
}
