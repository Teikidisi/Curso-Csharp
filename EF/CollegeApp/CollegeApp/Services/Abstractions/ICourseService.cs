using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Services.Abstractions
{
    public interface ICourseService
    {
        void RegisterCourse(CourseRegistryDTO courseRegistry);
        List<CourseDTO> GetAll();
        List<EnrollmentDTO> GetAllEnrollmentsOfId(int studentId);
        List<CourseDTO> GetAvailable(int studentId);
        string GetCourseName(int courseID);
        CourseDTO GetCourseById(int courseID);
        void EditCourse(CourseDTO courseEdit);
        int GetTotalStudents(int courseId);
        void DeleteCourse(int courseID);
    }
}
