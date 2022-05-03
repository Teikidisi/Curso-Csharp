using CollegeApp.Services.Abstractions;
using Model;
using Model.Entities;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext context = new AppDbContext();

        public void RegisterCourse(CourseRegistryDTO courseRegistry)
        {
            var course = new Course(courseRegistry.Title, courseRegistry.Credits);

            try
            {
                context.Courses.Add(course);
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CourseDTO> GetAll()
        {
            var courses = context.Courses.Select(c => new CourseDTO
            {
                Id = c.Id,
                Title = c.Title,
                Credits = c.Credits,
                MaxCapacity = c.MaxCapacity
            }).ToList();

            if (!courses.Any())
                throw new Exception("There are no courses registered.");
            return courses;
        }

        public List<EnrollmentDTO> GetAllEnrollmentsOfId(int studentID)
        {
            var enrollments = context.Enrollments.Where(e => e.Active == true).Select(c => new EnrollmentDTO
            {
                StudentID = c.StudentId,
                CourseID = c.CourseId
            }).Where(s => s.StudentID.Equals(studentID)).ToList();

            if (!enrollments.Any())
                throw new Exception("There are no enrollments.");

            return enrollments;
        }

        public List<CourseDTO> GetAvailable(int studentId)
        {
            var courses = context.Courses.Where(c => !c.Enrollments.Select(c => c.StudentId).Contains(studentId) || c.Enrollments.Where(e => e.Active == false).Select(c => c.StudentId).Contains(studentId))
                .Select(c => new CourseDTO
                {
                    Id = c.Id,
                    Title = c.Title,
                    Credits = c.Credits
                }).ToList();

            if (!courses.Any())
                throw new Exception("There are no courses available.");

            return courses;
        }

        public string GetCourseName(int courseID)
        {
            var course = context.Courses.Where(c => c.Id.Equals(courseID)).Select(c => c.Title).FirstOrDefault();
            if (course == null || course == "")
                return "That course does not exist";

            return course;
        }

        public CourseDTO GetCourseById(int courseID)
        {
            var course = context.Courses.Where(c => c.Id.Equals(courseID)).Select(c => new CourseDTO
            {
                Id = c.Id,
                Title = c.Title,
                Credits = c.Credits,
                MaxCapacity = c.MaxCapacity
            }).FirstOrDefault();
            return course;
        }

        public void EditCourse(CourseDTO courseEdit)
        {
            var oldCourse = context.Courses.Where(c => c.Id == courseEdit.Id).FirstOrDefault();
            if (oldCourse == null)
                throw new Exception("Could not find the Course");

            oldCourse.Title = courseEdit.Title;
            oldCourse.Credits = courseEdit.Credits;
            oldCourse.MaxCapacity = courseEdit.MaxCapacity;

            context.SaveChanges();
        }

        public int GetTotalStudents(int courseId)
        {
            var count = context.Enrollments.Where(e => e.Active == true).Count(c => c.CourseId == courseId);
            return count;
        }

        public void DeleteCourse(int courseID)
        {
            var deleteCourse = context.Courses.Where(c => c.Id.Equals(courseID)).FirstOrDefault();
            //var deleteEnrollments = context.Enrollments.Where(e => e.CourseId.Equals(courseID));

            if (deleteCourse == null)
                throw new Exception("That course could not be found.");
            try
            {
                context.Courses.Remove(deleteCourse);

                //foreach (var enroll in deleteEnrollments)
                //{
                //    context.Enrollments.Remove(enroll);
                //}

                context.SaveChanges();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
