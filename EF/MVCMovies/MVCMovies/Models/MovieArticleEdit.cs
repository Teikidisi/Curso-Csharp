using MVCMovies.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCMovies.Models
{
    public class MovieArticleEdit
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(512)]
        public string Body { get; set; }

        public MovieArticles ToEntity()
        {
            return new MovieArticles(Id, Title, Body);
        }
    }
}
