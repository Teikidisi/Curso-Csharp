using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class CourseRegistryDTO
    {
        public string Title { get; set; }
        public int Credits { get; set; }

        public void Validation()
        {
            if (string.IsNullOrEmpty(Title))
                throw new ArgumentNullException("'Title' cannot be empty.");
            if (Credits <= 0)
                throw new InvalidOperationException("'Credits' must be a positive number.");
        }
    }
}
