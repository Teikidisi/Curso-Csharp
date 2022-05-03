using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int MaxCapacity { get; set; }
        public void ValidateCourseID()
        {
            if (Id <= 0)
                throw new Exception("'Course ID' must be a positive number");
        }
        public void ValidateTitle()
        {
            if (string.IsNullOrEmpty(Title))
                throw new ArgumentNullException("'Title' cannot be empty.");
        }
        public void ValidateCredits()
        {
            if (Credits <= 0)
                throw new Exception("'Course ID' must be a positive number");
        }
        public void ValidateCapacity()
        {
            if (MaxCapacity < 0)
                throw new Exception("'Course ID' must be a positive number");
        }
    }
}
