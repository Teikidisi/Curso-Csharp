using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ASPNET_Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? City { get; set; }

        public ApplicationUser(string userName, string name)
        {
            UserName = userName;
            Name = name;
        }

    }
}
