using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Genre
    {
   
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }

        public Genre(string name)
        {
            Name = name;
        }
    }
}
