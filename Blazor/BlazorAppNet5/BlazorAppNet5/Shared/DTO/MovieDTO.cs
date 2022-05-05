using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppNet5.Shared.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Poster { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
