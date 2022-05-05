using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppNet5.Shared.DTO
{
    public class ActorDTO
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get;set; }
        [Required]
        public string LastName { get;set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        public int YearsActive { get; set; }
    }
}
