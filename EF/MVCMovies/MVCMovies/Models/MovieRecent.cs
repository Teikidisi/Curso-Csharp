using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCMovies.Models
{
    public class MovieRecent
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [Column(TypeName = "date")]
        public string ReleaseDate { get; set; }
    }
}
