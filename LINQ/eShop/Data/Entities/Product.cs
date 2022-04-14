using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
        public string Sku { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public Subdepartment Subdepartment { get; set; }

        public Product(string name, decimal price, string description, string brand, int id, string sku, int stock = 1 )
        {
            if (price < 0)
                throw new InvalidOperationException("El precio no puede ser menor a 0.");
            if (stock <= 0)
                throw new InvalidOperationException("El stock tiene que ser mayor a 0.");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre del producto no puede estar vacío.");
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException("La descripción no puede estar vacía.");
            if (string.IsNullOrEmpty(brand))
                throw new ArgumentNullException("La marca no puede estar vacía.");
            if (string.IsNullOrEmpty(sku))
                throw new ArgumentNullException("El SKU no puede estar vacío.");
            Name = name;
            Price = price;
            Description = description;
            Brand = brand;
            Id = id;
            Sku = sku;
            Stock = stock;

        }
        public void Update(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public void AddSubdepartment(Subdepartment subdepartment)
        {
            if (subdepartment == null)
                throw new ArgumentNullException("Se requiere un subdepartamento.");
            Subdepartment = subdepartment;
        }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Brand}\t{Sku}\t{Stock}\t{Description}\t{Price}\t{Subdepartment?.Name}\t{Subdepartment?.Department?.Name}";
        }

    }


    
}
