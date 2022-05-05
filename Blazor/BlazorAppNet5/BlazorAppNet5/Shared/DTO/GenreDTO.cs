using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppNet5.Shared.DTO
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GenreDTOValidator : AbstractValidator<GenreDTO>
    {
        public GenreDTOValidator()
        {
            RuleFor(g => g.Name).NotEmpty().MaximumLength(15).WithName("Genre");
        }
    }
}
