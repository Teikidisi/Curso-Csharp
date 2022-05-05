using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppNet5.Shared.DTO
{
    public class ActorDTO
    {
        public int Id { get; set; }
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public DateTime DateOfBirth { get; set; }
        public int YearsActive { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }

    public class ActorDTOValidator : AbstractValidator<ActorDTO>
    {
        public ActorDTOValidator()
        {
            DateTime minDate = new DateTime(1800, 01, 01);
            RuleFor(g => g.FirstName).NotEmpty().MaximumLength(30).WithName("First Name");
            RuleFor(g => g.LastName).NotEmpty().MaximumLength(50).WithName("Last Name");
            RuleFor(g => g.YearsActive).GreaterThan(0).WithName("Years Active");
            RuleFor(g => g.DateOfBirth).GreaterThan(minDate);
            RuleFor(g => g.Description).MaximumLength(100);
        }
    }
}
