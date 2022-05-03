using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppDbContextSeed
    {
        public static Task SeedAsync(AppDbContext context)
        {
            if (!context.Students.Any())
            {
                var seedStudents = new List<Student>
                {
                    new Student{CodeNumber = "M02771", FirstName="Mario",LastName="Lopez"},
                    new Student { CodeNumber= "T027971", FirstName="Jaime",LastName="Hernandez"},
                    new Student {CodeNumber="M2930", FirstName="Laurita", LastName="Garza"}
                };

                foreach (var student in seedStudents)
                {
                    context.Students.Add(student);
                }
                context.SaveChanges();
            }
            if (!context.Courses.Any())
            {
                var seedCourses = new List<Course>
                {
                    new Course {Title= "Chemistry", Credits = 8},
                    new Course {Title = "Spanish", Credits = 4}
                };
                foreach(var course in seedCourses)
                {
                    context.Courses.Add(course);
                }
                context.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
}
