using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Services.Abstractions
{
    public interface IStudentService
    {
        void RegisterStudent(StudentRegistryDTO studentRegistry);
        StudentDTO GetByCodeNumber(string codeNumber);
        void AssignCourse(CourseAssignmentDTO courseAssignment);
        List<EnrollmentDTO> GetEnrolled(int studentId);
        void UpdateGrade(EnrollmentDTO enrollmentValues);
        StudentEvaluationDTO GetEvaluationByCodeNumber(string codeNumber);
        void Evaluate(StudentEvaluationDTO evaluation);
        bool CheckUnique(string codeNumber);
        void Unenroll(EnrollmentDTO enroll);
    }
}
