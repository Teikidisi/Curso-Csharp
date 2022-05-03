using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class StudentEnrollmentDTO
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Grade? Grade { get; set; }
    }
}
