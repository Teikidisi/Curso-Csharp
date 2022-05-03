namespace MVCMovies.Models
{
    public class MovieFilters
    {
        public string? SearchTitle { get; set; }
        public string? SearchGenre { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public Rating? Rating { get; set; }
        public int? ActorID { get; set; }
    }
}
