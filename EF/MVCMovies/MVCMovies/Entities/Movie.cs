using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength =3)]
        public string Title { get; set; }
        [Display(Name ="Release Date")]
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        [Range(1,100, ErrorMessage = "The price needs to be set between 1-100.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-z\s]*$", ErrorMessage = "Genre can only contain letters.")]
        public string Genre { get; set; }
        [Required]
        //[StringLength(5)]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Invalid Genre format detected.")]
        public Rating Rating { get; set; } //PG-13
        //public string Rating { get; set; }s
        public ICollection<Actor> Actors { get; set; } = new List<Actor>(); //ICollection no está indexado
        public ICollection<UserRate> Rates { get; set; } = new List<UserRate>();
        public string PosterUri { get; set; }


    }
    public enum Rating
    {
        G,
        PG,
        PG13,
        R,
        NC17,
    }
}
