using System.ComponentModel.DataAnnotations;

namespace BlazorAppNet5.Shared.DTO
{
    public class GenreDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
