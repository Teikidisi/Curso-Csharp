using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Actor
    {
        
        public int Id { get; set; }
        [Required]
        public  string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int YearsActive { get; set; }
        public string Image { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
