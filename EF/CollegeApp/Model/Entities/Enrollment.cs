using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; } = (Grade?)5;
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public bool Active { get; set; } = true;

        public Enrollment() { }

        public Enrollment(int studentId, int courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }

    }
}
