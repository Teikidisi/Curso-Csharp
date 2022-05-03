using CollegeApp.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entities;
using Shared.Dto;
using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext context = new AppDbContext();

        public void RegisterStudent(StudentRegistryDTO studentRegistry)
        {
            var student = new Student(studentRegistry.CodeNumber, studentRegistry.FirstName, studentRegistry.LastName);
            try
            {
                context.Students.Add(student);
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CheckUnique(string codeNumber)
        {
            var student = context.Students.Where(s => s.CodeNumber.Equals(codeNumber)).Any();
            return student;
        }

        public StudentDTO GetByCodeNumber(string codeNumber)
        {
            var student = context.Students.Select(s => new StudentDTO
            {
                Id = s.Id,
                CodeNumber = s.CodeNumber,
                FirstName = s.FirstName,
                LastName = s.LastName,
            }).FirstOrDefault(s => s.CodeNumber.ToLower().Equals(codeNumber.ToLower()));

            if (student is null)
                throw new Exception("Student does not exist");

            return student;
        }

        public void AssignCourse(CourseAssignmentDTO courseAssignment)
        {
            var student = context.Students.FirstOrDefault(s => s.CodeNumber.ToLower().Equals(courseAssignment.StudentCodeNumber.ToLower()));
            var course = context.Courses.Include(c => c.Enrollments).FirstOrDefault(c => c.Id.Equals(courseAssignment.CourseId));
            
            if (student is null)
                throw new ArgumentNullException("Student does not exist");
            if (course is null)
                throw new ArgumentNullException("Course does not exist");

            if (course.Enrollments.Where(e => e.Active == true).Select(e => e.StudentId).Contains(student.Id))
                throw new Exception("Student already assigned to this course.");
            else if (course.Enrollments.Where(e => e.Active == false).Select(e => e.StudentId).Contains(student.Id))
            {
                var enrollment = context.Enrollments.Where(e => e.StudentId == student.Id && e.CourseId == course.Id).FirstOrDefault();
                if (enrollment != null)
                {
                    enrollment.Active = true;
                    context.SaveChanges();
                }
            }
            else
            {
                var enrollment = context.Enrollments.Add(new Enrollment(student.Id, course.Id));
                student.Enrollments.Add(enrollment.Entity);
                course.Enrollments.Add(enrollment.Entity);
                context.SaveChanges();
            }

        }

        public List<EnrollmentDTO> GetEnrolled(int studentId)
        {
            var enrolled = context.Enrollments.Where(c => c.StudentId == studentId).Select(c => new EnrollmentDTO
            {
                StudentID = c.StudentId,
                CourseID = c.CourseId,
                Grade = (Grade)c.Grade,
            }).ToList();

            if (!enrolled.Any())
                throw new Exception("There are no courses available.");

            return enrolled;
        }

        public void UpdateGrade(EnrollmentDTO enrollmentValues)
        {
            var newEnrollment = context.Enrollments.Where(c => c.StudentId == enrollmentValues.StudentID && c.CourseId == enrollmentValues.CourseID && c.Active == true).FirstOrDefault();
            if (newEnrollment == null)
                throw new ApplicationException("That course cannot be updated.");
            newEnrollment.Grade = enrollmentValues.Grade;

            context.SaveChanges();
        }

        public StudentEvaluationDTO GetEvaluationByCodeNumber(string codeNumber)
        {
            var enrollments = context.Enrollments.Where(e => e.Student.CodeNumber.ToLower().Equals(codeNumber.ToLower())).Select(e => new StudentEnrollmentDTO
            {
                CourseId = e.CourseId,
                Title = e.Course.Title,
                Grade = e.Grade
            }).ToList();

            var evaluation = context.Students.Where(s => s.CodeNumber.ToLower().Equals(codeNumber.ToLower())).Select(s => new StudentEvaluationDTO
            {
                Student = new StudentDTO
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    CodeNumber = s.CodeNumber,
                },
                Enrollments = enrollments
            }).FirstOrDefault();

            if (evaluation is null)
                throw new ArgumentNullException("Student doesn't exist.");
            if (!enrollments.Any())
                throw new Exception("There are either no courses assigned to this student or all courses have been evaluated.");

            return evaluation;
        }

        public void Evaluate(StudentEvaluationDTO evaluation)
        {
            var enrollments = context.Enrollments.Where(e => e.StudentId.Equals(evaluation.Student.Id) && e.Active == true).ToList();

            try
            {
                foreach(var enrollment in enrollments)
                {
                    var x = evaluation.Enrollments.First(e => e.CourseId.Equals(enrollment.CourseId));
                    enrollment.Grade = x.Grade;
                }
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Unenroll(EnrollmentDTO enroll)
        {
            var enrollment = context.Enrollments.Where(e => e.StudentId == enroll.StudentID && e.CourseId == enroll.CourseID && e.Active == true).FirstOrDefault();
            if (enrollment != null)
            {
                enrollment.Active = false;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("That enrollment does not exist, can't unenroll.");
            }
        }
    }
}
