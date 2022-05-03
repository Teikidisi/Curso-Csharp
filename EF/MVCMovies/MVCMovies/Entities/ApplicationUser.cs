using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVCMovies.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public ICollection<UserRate> Rates { get; set; }

        public ApplicationUser(string userName, string name)
        {
            UserName = userName;
            Name = name;
        }
    }
}
