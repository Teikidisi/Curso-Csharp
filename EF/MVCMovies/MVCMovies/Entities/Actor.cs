using System.ComponentModel.DataAnnotations;

namespace MVCMovies.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Range(0,100)]
        [Display(Name = "Oscars Won")]
        public int OscarsWon { get; set; }
        public Sex Sex { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
        public ICollection<UserRateActor> Rates { get; set; } = new List<UserRateActor>();
    }

    public enum Sex
    {
        Male,
        Female
    }
}
