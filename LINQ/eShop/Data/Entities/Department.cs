using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Subdepartment> Subdepartments { get; set; }

        public Department(string name, List<Subdepartment> subdepartments)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre no puede estar vacío.");
            if (subdepartments == null || !subdepartments.Any())
                throw new InvalidOperationException("El departamento necesita subdepartamentos");
            Name = name;
            Subdepartments = subdepartments;
        }

        public override string ToString()
        {
            string subNames="";
            int iter = 1;
            foreach(var sub in Subdepartments)
            {
                subNames += iter+". "+sub.Name+",";
                iter++;
            }
            return $"Departamento: {Name} Subdepartamentos: {subNames}";
        }
    }

    
}
