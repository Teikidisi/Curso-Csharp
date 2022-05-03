namespace MVCMovies.Models
{
    public class MoviePopular
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<UserRate> Rates { get; set; } = new List<UserRate>();
    }
}
