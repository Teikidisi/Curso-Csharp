using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Subdepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>(); //o escribir new(); C#-10
        public virtual Department Department { get; set; }
        public int DepartmentID { get; set; }

        public Subdepartment() { }
        public Subdepartment(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre no puede estar vacío.");

            Name = name;
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public override string ToString()
        {
            return $"Subdepartamento: {Name}";
        }
    }
}
