using CollegeApp.Services.Abstractions;
using CollegeApp.Services.Implementations;
using Shared.Dto;
using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp
{
    public class Menu
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public Menu()
        {
            _studentService = new StudentService();
            _courseService = new CourseService();
        }

        public bool Show()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Student registration");
            Console.WriteLine("2. Course registration");
            Console.WriteLine("3. Course assignment");
            Console.WriteLine("4. Evaluate student performance");
            Console.WriteLine("5. Consult student performance");
            Console.WriteLine("6. Edit Course");
            Console.WriteLine("7. Dar de baja estudiante de un curso");
            Console.WriteLine("8. Delete Course");
            Console.WriteLine("9. Any other key to exit");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    RegisterStudent();
                    break;
                case "2":
                    Console.Clear();
                    RegisterCourse();
                    break;
                case "3":
                    Console.Clear();
                    AssignCourse();
                    break;
                case "4":
                    //Mostrar cursos donde estas inscrito , elegir que curso quieres evaluar, asignar un grado a esa materia
                    //ASignar los enums de Grade, dentro de un bucle que continue los updates, validar datos de entrada.
                    Console.Clear();
                    EvaluatePerformance();
                    //EvaluateStudentPerformance();
                    break;
                case "5":
                    Console.Clear();
                    ConsultStudentPerformance();
                    break;
                case "6":
                    Console.Clear();
                    EditCourse();
                    break;
                case "7":
                    Console.Clear();
                    DarDeBaja();
                    break;
                case "8":
                    Console.Clear();
                    BorrarCurso();
                    break;

                default:
                    return false;
            }
            return true;
        }

        private void BorrarCurso()
        {
            var courses = _courseService.GetAll();
            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.Id} Name: {course.Title} \tCredits:{course.Credits}");
            }

            Console.WriteLine("Enter the Course ID you want to delete: ");
            Console.Write("Course ID: ");
            try
            {
                string inputCourseID = Console.ReadLine();
                if (!Int32.TryParse(inputCourseID, out int CourseID))
                    throw new FormatException("The course ID is not valid");
                if (CourseID <= 0)
                    throw new Exception("'Course ID' must be a positive number");

                string courseNameSelected = _courseService.GetCourseName(CourseID);
                if (courseNameSelected == "That course does not exist")
                {
                    Console.WriteLine(courseNameSelected);
                    return;
                }
                Console.WriteLine($"\nYou will delete the course {CourseID}. {courseNameSelected}");
                Console.WriteLine("Confirm to proceed (y/n)");
                if (Console.ReadKey().Key != ConsoleKey.Y)
                {
                    Console.WriteLine("\nCancelling...");
                    return;
                }

                Console.WriteLine("\nWill delete");
                try
                {
                    _courseService.DeleteCourse(CourseID);
                    Console.WriteLine("Course has been deleted succesfully.");

                }catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            } catch(Exception ex) { Console.WriteLine(ex.ToString()); }
            finally
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }

        }

        private void RegisterStudent()
        {
            var studentRegistry = new StudentRegistryDTO();
            Console.WriteLine("Please enter the required information to register a new student:");
            Console.Write("Student Code Number: ");
            studentRegistry.CodeNumber = Console.ReadLine();
            Console.Write("First Name: ");
            studentRegistry.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            studentRegistry.LastName = Console.ReadLine();

            try
            {
                studentRegistry.Validation();

                bool unique = _studentService.CheckUnique(studentRegistry.CodeNumber);
                if (unique)
                {
                    Console.WriteLine("The Student Code Number is already in use, needs to be unique.");
                    return;
                }
                
                _studentService.RegisterStudent(studentRegistry);
                Console.WriteLine("Student registered correctly.");
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue;");
                Console.ReadLine();
            }


        }
        private void RegisterCourse()
        {
            var courseRegistry = new CourseRegistryDTO();
            Console.WriteLine("Please enter the required information to register a new course:");
            Console.Write("Title: ");
            courseRegistry.Title = Console.ReadLine();
            Console.Write("Credits: ");
            string input = Console.ReadLine();
            var isValid = Int32.TryParse(input, out int credits);
            if (!isValid)
            {
                Console.WriteLine("Please enter a valid number.\nPress any key to continue.");
                Console.ReadLine();
                return;
            }
            try
            {
                courseRegistry.Credits = credits;
                courseRegistry.Validation();

                _courseService.RegisterCourse(courseRegistry);
                Console.WriteLine("Course registered correctly.");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue;");
                Console.ReadLine();
            }
        }
        private void AssignCourse()
        {
            var courseAssignment = new CourseAssignmentDTO();
            var enrollment = new EnrollmentDTO();

            Console.WriteLine("Please enter the required information to assign a course");
            Console.Write("Student Enrollment Number:");

            try
            {
                courseAssignment.StudentCodeNumber = Console.ReadLine();
                courseAssignment.ValidateStudentCodeNumber();

                var student = _studentService.GetByCodeNumber(courseAssignment.StudentCodeNumber);
                var courses = _courseService.GetAvailable(student.Id);

                //var enroll = _courseService.GetAllEnrollmentsOfId(student.Id);
                //foreach (var e in enroll)
                //{
                //    Console.WriteLine($"CourseID: {e.CourseID} StudentID:{e.StudentID}");
                //}

                Console.WriteLine($"\nStudent DB ID: {student.Id}");
                Console.WriteLine($"\nStudent Information\nStudent Code Number: {student.CodeNumber}\tName: {student.FirstName} {student.LastName}");
                Console.WriteLine("\nAvailable courses:");

                //List<CourseDTO> noRepeat = new List<CourseDTO>();

                foreach(var course in courses)
                {
                    //if (!enroll.Any(e => e.StudentID == course.Id))
                    //{
                    //    noRepeat.Add(course);      
                    //}
                    Console.WriteLine($"ID: {course.Id}\tTitle: {course.Title}\tCredits: {course.Credits}");
                }

                //foreach(var course in noRepeat)
                //{
                //    Console.WriteLine($"ID: {course.Id}\tTitle: {course.Title}\tCredits: {course.Credits}");
                //}

                Console.WriteLine("\nPlease choose an option:");
                Console.Write($"Course ID: ");
                string input = Console.ReadLine();
                if(Int32.TryParse(input, out int courseId))
                {
                    courseAssignment.CourseId = courseId;
                    //if (noRepeat.Any(c => c.Id == courseId))
                    //{
                    //}
                    //else
                    //{
                    //    throw new Exception("No valid course ID entered.");
                    //}
                }
                else
                {
                    throw new Exception("Course ID must be a number");
                }
                
                courseAssignment.ValidateCourseTitle();
                
                int totalStudents = _courseService.GetTotalStudents(courseId);
                var courseToAdd = _courseService.GetCourseById(courseId);
                if (totalStudents < courseToAdd.MaxCapacity)
                {
                    _studentService.AssignCourse(courseAssignment);
                    Console.WriteLine("Student has been assigned to the course.");
                }
                else
                {
                    Console.WriteLine("The maximum Student Capacity for the course has been met, you cannot enter this course.");
                }

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }

        private void DarDeBaja()
        {
            var enrollmentCourse = new EnrollmentDTO();

            Console.WriteLine("Enter the Code Number of the student you want to dar de baja:");
            try
            {
                string StudentCodeNumber = Console.ReadLine();

                var student = _studentService.GetByCodeNumber(StudentCodeNumber);
                enrollmentCourse.StudentID = student.Id;
                enrollmentCourse.ValidateStudentID();

                Console.WriteLine("Here are the enrolled courses:");
                var enrolledcourses = _courseService.GetAllEnrollmentsOfId(student.Id);
                foreach(var course in enrolledcourses)
                {
                    string courseName = _courseService.GetCourseName(course.CourseID);
                    Console.WriteLine($"ID: {course.CourseID} Title: {courseName}");
                }

                Console.WriteLine("Enter course ID: ");
                string inputCourse = Console.ReadLine();
                bool isValid = Int32.TryParse(inputCourse, out int validCourseId);
                if (!isValid)
                    throw new ArgumentException("Course ID is not a valid format");

                enrollmentCourse.CourseID = validCourseId;
                enrollmentCourse.ValidateCourseID();

                string courseNameSelected = _courseService.GetCourseName(validCourseId);
                if (courseNameSelected == "That course does not exist")
                {
                    Console.WriteLine(courseNameSelected);
                    return;
                }
                Console.WriteLine($"\nThe student will be unenrolled from {validCourseId}. {courseNameSelected}");


                _studentService.Unenroll(enrollmentCourse);
                Console.WriteLine("\nShowing the new Student enrollments ");
                enrolledcourses = _courseService.GetAllEnrollmentsOfId(student.Id);
                foreach (var course in enrolledcourses)
                {
                    string courseName = _courseService.GetCourseName(course.CourseID);
                    Console.WriteLine($"ID: {course.CourseID} Title: {courseName}");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }

        private void EvaluatePerformance()
        {
            

            Console.WriteLine("Evaluate Student Performance.");
            Console.WriteLine("Please enter the ID of the student you want to evaluate: ");
            try
            {
                string codeNumberInput = Console.ReadLine();
                if (string.IsNullOrEmpty(codeNumberInput))
                    throw new ArgumentNullException("'Code Number' must not be empty.");

                var student = _studentService.GetByCodeNumber(codeNumberInput);
                

                Console.WriteLine($"The student ID: {student.Id} NAME: {student.FirstName} {student.LastName} will be evaluated. ");

                
                bool cycle = true;
                while (cycle)
                {
                    List<EnrollmentDTO> enrolledCourses = _studentService.GetEnrolled(student.Id);
                    Console.WriteLine("Here are their enrolled classes and their grades:");
                    foreach(var course in enrolledCourses)
                    {
                        string courseName = _courseService.GetCourseName(course.CourseID);
                        Console.WriteLine($"ID: {course.CourseID} Course: {courseName} Grade: {course.Grade}");
                    }

                    Console.WriteLine("Enter the Course ID you want to change grade: ");
                    string input = Console.ReadLine();
                    if (Int32.TryParse(input, out int courseId))
                    {
                        var available = enrolledCourses.FirstOrDefault(c => c.CourseID == courseId);
                        if (available == null)
                            throw new Exception("The student is not enrolled to that course.");
                        EnrollmentDTO enrollmentStudent = new EnrollmentDTO();
                        enrollmentStudent.StudentID = student.Id;
                        enrollmentStudent.CourseID = courseId;
                        enrollmentStudent.ValidateCourseID();

                        string selectedCourse = _courseService.GetCourseName(courseId);
                        if (selectedCourse == "That course does not exist")
                        {
                            Console.WriteLine(selectedCourse);
                            return;
                        }

                        Console.WriteLine($"You have selected {courseId} = {selectedCourse}");
                        Console.WriteLine("Here are the Grades to enter: A B C D E F");
                        Console.WriteLine("Please enter the new grade: ");
                        string inputGrade = Console.ReadLine().ToUpper();

                        if (Enum.TryParse(inputGrade, out Grade courseGrade))
                        {
                            enrollmentStudent.Grade = courseGrade;
                            _studentService.UpdateGrade(enrollmentStudent);
                            Console.WriteLine("Grade updated succesfully.");
                        }
                        else
                        {
                            Console.WriteLine("That value is not a correct value.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("That value is not accepted.");
                    }
                    Console.WriteLine("Do you want to change another grade? (y/n)");
                    if (Console.ReadKey().Key == ConsoleKey.N)
                    {
                        cycle = false;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }

        }

        private StudentEvaluationDTO ConsultStudentPerformance()
        {
            Console.WriteLine("Please enter the required information to consult student performance");
            Console.WriteLine("Student Code NUmber");
            var input = Console.ReadLine();

            try
            {
                var evaluation = _studentService.GetEvaluationByCodeNumber(input);
                Console.WriteLine($"\nStudent Information\nStudent Code Number: {evaluation.Student.CodeNumber}\tName: {evaluation.Student.FirstName}\t{evaluation.Student.LastName}");
                Console.WriteLine("\nEnrolled Courses:");

                foreach(var enrollment in evaluation.Enrollments)
                {
                    var grade = enrollment.Grade == null ? "-" : enrollment.Grade.ToString();
                    Console.WriteLine($"{enrollment.CourseId}. {enrollment.Title}\t\t{grade}");
                }
                Console.ReadLine();

                return evaluation;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return null;
            }
        }

        public void EvaluateStudentPerformance()
        {
            var con = false;
            var isValidUpdate = false;
            var evaluation = ConsultStudentPerformance();

            if (evaluation is null)
                return;

            Console.WriteLine("\n**Grade options are the following A-B-C-D-E-F");

            do
            {
                Console.WriteLine("\nPlease choose a course to evaluate.");
                Console.WriteLine("course Id: ");
                var inputId = Console.ReadLine();
                var IsValid = Int32.TryParse(inputId, out var id);

                var exists = evaluation.Enrollments.Exists(e => e.CourseId.Equals(id));

                if (!exists)
                {
                    Console.WriteLine("The course you entered is not correct.");
                    return;
                }
                if (!IsValid)
                {
                    Console.WriteLine("You must enter a valid number.");
                    return;
                }

                Console.WriteLine("Assign a grade: ");
                var inputGrade = Console.ReadLine();
                IsValid = Enum.TryParse(inputGrade, out Grade grade);
                if (!IsValid)
                {
                    Console.WriteLine("You must enter a valid grade.");
                    return;
                }

                var index = evaluation.Enrollments.FindIndex(e => e.CourseId.Equals(id));
                evaluation.Enrollments.ElementAt(index).Grade = grade;

                Console.WriteLine("do you want to assign another grade?");
                var input = Console.ReadLine();

                con = input.ToLower().Equals("y");
                if (!con)
                    isValidUpdate = true;
                if (!isValidUpdate)
                    return;

                _studentService.Evaluate(evaluation);

            } while (con);
        }

        public void EditCourse()
        {
            CourseDTO courseToEdit = new CourseDTO();

            //Editar valores del curso, Agregar campo de capacidad.
            Console.WriteLine("Available courses to edit: ");
            var courses = _courseService.GetAll();
            foreach(var course in courses)
            {
                Console.WriteLine($"{course.Id}. Name: {course.Title} Credits: {course.Credits} Capacity: {course.MaxCapacity}");
            }

            Console.WriteLine("Please enter the CourseID you want to edit: ");
            string inputID = Console.ReadLine();

            var isValid = Int32.TryParse(inputID, out var id);

            if (!isValid)
            {
                Console.WriteLine("The id is not correct.");
                return;
            }

            var selectedCourse = _courseService.GetCourseById(id);

            courseToEdit.Id = id;
            courseToEdit.ValidateCourseID();
            
            courseToEdit.Credits = selectedCourse.Credits;
            courseToEdit.Title = selectedCourse.Title;
            courseToEdit.MaxCapacity = selectedCourse.MaxCapacity;
            
            Console.WriteLine("Please enter the field you want to edit: ");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Credits");
            Console.WriteLine("3. Max Capacity");
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Please enter the new name:");
                    var inputName = Console.ReadLine();
                    courseToEdit.Title = inputName;
                    courseToEdit.ValidateTitle();
                    break;

                case "2":
                    Console.WriteLine("Please enter the new credits:");
                    var inputCredits = Console.ReadLine();
                    isValid = Int32.TryParse(inputCredits, out int credits);
                    if (!isValid)
                    {
                        Console.WriteLine("Incorrect value entered");
                        return;
                    }
                    courseToEdit.Credits = credits ;
                    courseToEdit.ValidateCredits();
                    break;

                case "3":
                    Console.WriteLine("Please enter the new Max Student Capacity:");
                    var inputCap = Console.ReadLine();
                    isValid = Int32.TryParse(inputCap, out int maxcap);
                    if (!isValid)
                    {
                        Console.WriteLine("Incorrect value entered");
                        return;
                    }
                    courseToEdit.MaxCapacity = maxcap;
                    courseToEdit.ValidateCapacity();
                    break;

                default:
                    break;
            }

            _courseService.EditCourse(courseToEdit);
            Console.WriteLine("New course lineup:");
            courses = _courseService.GetAll();
            foreach(var course in courses)

            {
                Console.WriteLine($"{course.Id}. Name: {course.Title} Credits: {course.Credits} Capacity: {course.MaxCapacity}");
            }
            Console.ReadLine();

        }
    }
}
