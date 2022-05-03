using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class CourseAssignmentDTO
    {
        public string StudentCodeNumber { get; set; }
        
        public int CourseId { get; set; }
        public void ValidateCourseTitle()
        {
            if (CourseId <= 0)
                throw new Exception("'Course ID' must be a positive number");
        }

        public void ValidateStudentCodeNumber()
        {
            if (string.IsNullOrEmpty(StudentCodeNumber))
                throw new ArgumentNullException("'Code Number' must not be empty.");
        }
    }
}
