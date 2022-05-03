using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int SubdepartmentID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public virtual Subdepartment Subdepartment { get; set; }
        public virtual ICollection<Carrito> Carritos { get; set; }
        public virtual ICollection<ProductosAComprar> ProductosAComprars { get; set; }

        public Product() { }
    }
}
