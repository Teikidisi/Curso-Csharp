using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Subdepartment> Subdepartments { get; set; }
        public virtual ICollection<Subdepartment> Subdepartments { get; set; }

        public Department() { }
    }
}
