using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class StudentEvaluationDTO
    {
        public StudentDTO Student { get; set; }
        public List<StudentEnrollmentDTO> Enrollments { get; set; }
    }
}
