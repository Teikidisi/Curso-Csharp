using System.ComponentModel.DataAnnotations;

namespace MVCMovies.Models
{
    public class ContactForm
    {
        [Required, StringLength(10)]
        public string Name { get; set; }
        [Required, EmailAddress, Display(Name= "Email Address")]
        public string EmailAddress { get; set; }
        [Required,MaxLength(256)]
        public string Message { get; set; }
    }
}
