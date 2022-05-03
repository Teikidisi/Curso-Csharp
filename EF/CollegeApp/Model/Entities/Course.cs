using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int MaxCapacity { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public Course() { }
        public Course(string title, int credits)
        {
            Title = title;
            Credits = credits;
        }

        public Course(string title, int credits, int maxC = 0)
        {
            Title = title;
            MaxCapacity = maxC;
            Credits = credits;
        }
    }
}
