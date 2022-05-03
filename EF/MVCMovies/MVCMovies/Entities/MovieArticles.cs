using Ardalis.GuardClauses;

namespace MVCMovies.Entities
{
    public class MovieArticles
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Body { get; private set; }
        public DateTime PublishedAt { get; private set; }
        public string? Source { get; private set; }
        public string? Category { get; private set; }

        public MovieArticles(string title, string body, string category, string source = null)
        {
            Title = Guard.Against.NullOrEmpty(title, nameof(title));
            Body = Guard.Against.NullOrEmpty(body, nameof(body));
            Category = Guard.Against.NullOrEmpty(category, nameof(category));
            Source = source;
            PublishedAt = DateTime.Now;

        }

        public MovieArticles(int id, string title, string body)
        {
            Id = Guard.Against.NegativeOrZero(id, nameof(id));
            Title = Guard.Against.NullOrEmpty(title, nameof(title));
            Body = Guard.Against.NullOrEmpty(body, nameof(body));
        }

        public void Edit(string title, string body)
        {
            Title = Guard.Against.NullOrEmpty(title, nameof(title));
            Body = Guard.Against.NullOrEmpty(body, nameof(body));
        }
    }
}
