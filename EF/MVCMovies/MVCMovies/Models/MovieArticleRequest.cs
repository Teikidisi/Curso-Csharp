using MVCMovies.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCMovies.Models
{
    public class MovieArticleRequest
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(512)]
        public string Body { get; set; }
        [Url]
        public string? Source { get; set; }
        [Required]
        [MaxLength(100)]
        public string Category { get; set; }

        public MovieArticles ToEntity()
        {
            return new MovieArticles(Title, Body, Category, Source);
        }
    }
}
