using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class EnrollmentDTO
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public Grade Grade { get; set; }

        public void ValidateCourseID()
        {
            if (CourseID <= 0)
                throw new Exception("'Course ID' must be a positive number");
        }
        public void ValidateStudentID()
        {
            if (StudentID <= 0)
                throw new Exception("'Student ID' must be a positive number");
        }

        public void ValidateGrade()
        {
            if (!Grade.IsDefined(typeof(Grade), Grade))
            {
                throw new Exception("'Grade' needs to be a valid grade.");
            }
        }
    }
}
