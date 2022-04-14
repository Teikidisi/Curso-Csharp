using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class TestData
    {
        public static List<Product> ProductList = new List<Product>()
        {
         new Product("Jabones",10,"Jabon de vainilla","suavitel", 1,"jvs1",100),
         new Product("Shampoo",20,"huele a chicle   ","Loreal  ", 2,"sh2 ", 3),
         new Product("Esponja",2 ,"Color amarillo   ","Mamamba ", 3,"s4f3", 50),
         new Product("Carpeta",50,"Para atletas     ","Suavitel", 4,"g3r4", 90)
        };

        public static List<Department> DepartmentList = new List<Department>()
        {
            new Department("Electrónicos", new List<Subdepartment> //no necesita () si no tiene parametros el constructor
            {
                new Subdepartment("TVs"),
                new Subdepartment("Celulares"),
                new Subdepartment("Audio")
            }),
            new Department("Muebles", new List<Subdepartment>
            {
                new Subdepartment("Cocina"),
                new Subdepartment("Comedor"),
                new Subdepartment("Sala"),
            }),
            new Department("Alimentos", new List<Subdepartment>
            {
                new Subdepartment("Lacteos"),
                new Subdepartment("Carnes frías"),
                new Subdepartment("Pastas"),
            })
        };

        public static List<Provider> GetProviders()
        {
            var providers = new List<Provider>();
            var p1 = new Provider(1, "Gamesa", "proveedor@gamesa.com");
            p1.AddAddress("islas 123", "Mexicali");
            p1.AddPhoneNumber("6861234567");
            providers.Add(p1);
            var p2 = new Provider(2, "Levis", "proveedor@levis.com");
            p1.AddAddress("islas levis 123", "Tijuana");
            p1.AddPhoneNumber("6641234567");
            providers.Add(p2);
            var p3 = new Provider(3, "mercado Chuchita", "proveedor@chuchita.com");
            p1.AddAddress("islas chu 123", "Tijuana");
            p1.AddPhoneNumber("6641231644");
            providers.Add(p3);
            return providers;
        }

    }

    
}
