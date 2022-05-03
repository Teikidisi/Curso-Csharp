using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class StudentGradesDTO
    {
        public string StudentCodeNumber { get; set; }
        public int CourseId { get; set; }
        public Grade CourseGrade { get;set; }
        public int StudentId { get; set; }
        public void ValidateStudentCodeNumber()
        {
            if (string.IsNullOrEmpty(StudentCodeNumber))
                throw new ArgumentNullException("'Code Number' must not be empty.");
        }
        public void ValidateCourseID()
        {
            if (CourseId <= 0)
                throw new Exception("'Course ID' must be a positive number");
        }

        public void ValidateGrade()
        {
            if (!Grade.IsDefined(typeof(Grade), CourseGrade))
                throw new Exception("'Grade' needs to be a valid grade.");
        }
    }
}
